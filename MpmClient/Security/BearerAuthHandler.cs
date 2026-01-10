using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MpmClient.Security
{
    internal sealed class BearerAuthHandler : DelegatingHandler
    {
        private readonly TokenStore _tokenStore;

        public BearerAuthHandler(TokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = _tokenStore.AccessToken;
            if (!string.IsNullOrWhiteSpace(accessToken) && request.Headers.Authorization is null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}