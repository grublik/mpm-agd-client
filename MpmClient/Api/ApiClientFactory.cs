using System;
using System.Net.Http;
using MpmClient.Security;

namespace MpmClient.Api
{
    internal sealed class ApiClientFactory
    {
        private readonly Func<string> _baseUrlProvider;
        private readonly TokenStore _tokenStore;

        public ApiClientFactory(TokenStore tokenStore, Func<string> baseUrlProvider)
        {
            _tokenStore = tokenStore;
            _baseUrlProvider = baseUrlProvider;
        }

        public HttpClient CreateHttpClient()
        {
            var handlerChain =
                new JwtRefreshHandler(_tokenStore, _baseUrlProvider)
                {
                    InnerHandler =
                        new BearerAuthHandler(_tokenStore)
                        {
                            InnerHandler = new HttpClientHandler()
                        }
                };
        
            var httpClient = new HttpClient(handlerChain, disposeHandler: true);

            var baseUrl = NormalizeBaseUrl(_baseUrlProvider());
            if (!string.IsNullOrWhiteSpace(baseUrl))
                httpClient.BaseAddress = new Uri(baseUrl, UriKind.Absolute);

            return httpClient;
        }

        public TokenClient CreateTokenClient(string baseUrl, HttpClient httpClient)
            => new TokenClient(NormalizeBaseUrl(baseUrl), httpClient);

        public RefreshClient CreateRefreshClient(string baseUrl, HttpClient httpClient)
            => new RefreshClient(NormalizeBaseUrl(baseUrl), httpClient);

        public ProfileClient CreateProfileClient(string baseUrl, HttpClient httpClient)
            => new ProfileClient(NormalizeBaseUrl(baseUrl), httpClient);

        private static string NormalizeBaseUrl(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                return string.Empty;

            if (!baseUrl.Contains("://", StringComparison.Ordinal))
                baseUrl = "http://" + baseUrl;

            if (!baseUrl.EndsWith("/", StringComparison.Ordinal))
                baseUrl += "/";

            return baseUrl;
        }
    }
}