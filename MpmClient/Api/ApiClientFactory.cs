using System;
using System.Net.Http;
using MpmClient.Security;

namespace MpmClient.Api
{
    internal sealed class ApiClientFactory
    {
        private readonly TokenStore _tokenStore;

        public ApiClientFactory(TokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }

        public HttpClient CreateHttpClient()
        {
            var handler = new BearerAuthHandler(_tokenStore)
            {
                InnerHandler = new HttpClientHandler()
            };

            return new HttpClient(handler, disposeHandler: true);
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

            // Accept "127.0.0.1:8000" and "http://127.0.0.1:8000"
            if (!baseUrl.Contains("://", StringComparison.Ordinal))
                baseUrl = "http://" + baseUrl;

            return baseUrl;
        }
    }
}