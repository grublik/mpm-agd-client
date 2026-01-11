using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MpmClient.Api;

namespace MpmClient.Security
{
    internal sealed class JwtRefreshHandler : DelegatingHandler
    {
        private readonly TokenStore _tokenStore;
        private readonly Func<string> _baseUrlProvider;

        public JwtRefreshHandler(TokenStore tokenStore, Func<string> baseUrlProvider)
        {
            _tokenStore = tokenStore;
            _baseUrlProvider = baseUrlProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpRequestMessage? clonedRequest = null;

            // We can only retry if we can clone the request body (buffered into memory).
            if (request.Content is not null)
                clonedRequest = await CloneHttpRequestMessageAsync(request, cancellationToken).ConfigureAwait(false);

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (response.StatusCode != HttpStatusCode.Unauthorized)
                return response;

            if (clonedRequest is null)
                return response;

            // If no refresh token, nothing to do.
            if (string.IsNullOrWhiteSpace(_tokenStore.RefreshToken))
                return response;

            // Only one refresh at a time.
            await _tokenStore.RefreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                // Another request may have refreshed already while we waited.
                // If token changed since the original request was sent, just retry once.
                // (We don't have the original token here, so we simply attempt refresh only if still 401.)

                var refreshed = await TryRefreshAsync(cancellationToken).ConfigureAwait(false);
                if (!refreshed)
                    return response;
            }
            finally
            {
                _tokenStore.RefreshLock.Release();
            }

            response.Dispose();
            return await base.SendAsync(clonedRequest, cancellationToken).ConfigureAwait(false);
        }

        private async Task<bool> TryRefreshAsync(CancellationToken cancellationToken)
        {
            var refresh = _tokenStore.RefreshToken;
            if (string.IsNullOrWhiteSpace(refresh))
                return false;

            var baseUrl = _baseUrlProvider();
            if (string.IsNullOrWhiteSpace(baseUrl))
                return false;

            // IMPORTANT: avoid recursive refresh by using a plain HttpClient (no refresh handler).
            using var httpClient = new HttpClient();
            var refreshClient = new RefreshClient(baseUrl, httpClient);

            var body = new TokenRefresh
            {
                // many APIs only require refresh; NSwag model requires both, so we fill both
                Refresh = refresh,
                Access = _tokenStore.AccessToken ?? string.Empty
            };

            try
            {
                var result = await refreshClient.CreateAsync(body, body.Access, body.Refresh, cancellationToken).ConfigureAwait(false);

                if (string.IsNullOrWhiteSpace(result.Access))
                    return false;

                _tokenStore.AccessToken = result.Access;

                // Some backends rotate refresh token; if returned, keep it.
                if (!string.IsNullOrWhiteSpace(result.Refresh))
                    _tokenStore.RefreshToken = result.Refresh;

                return true;
            }
            catch
            {
                _tokenStore.Clear();
                return false;
            }
        }

        private static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Version = request.Version
            };

            foreach (var header in request.Headers)
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

            foreach (var prop in request.Options)
                clone.Options.Set(new HttpRequestOptionsKey<object?>(prop.Key), prop.Value);

            if (request.Content is not null)
            {
                var ms = new MemoryStream();
                await request.Content.CopyToAsync(ms, cancellationToken).ConfigureAwait(false);
                ms.Position = 0;

                var content = new StreamContent(ms);
                foreach (var header in request.Content.Headers)
                    content.Headers.TryAddWithoutValidation(header.Key, header.Value);

                clone.Content = content;
            }

            return clone;
        }
    }
}