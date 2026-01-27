using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using MpmClient.Api;
using MpmClient.Modules.Users.Views.Interface;
using MpmClient.Security;

namespace MpmClient.Modules.Users.Presenters
{
    internal sealed class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly ApiClientFactory _apiClientFactory;
        private readonly TokenStore _tokenStore;

        public LoginPresenter(ILoginView view, ApiClientFactory apiClientFactory, TokenStore tokenStore)
        {
            _view = view;
            _apiClientFactory = apiClientFactory;
            _tokenStore = tokenStore;

            _view.SetServerAddress(Settings.Default.MpmApiServerAddr);
            _view.LoginAttempted += OnLoginAttempted;
        }

        // Update the event handler signature to match nullability of EventHandler delegate
        private async void OnLoginAttempted(object? sender, EventArgs e)
        {
            try
            {
                await LoginAsync().ConfigureAwait(true);

                Settings.Default.MpmApiServerAddr = _view.ServerAddress;
                Settings.Default.Save();

                if (_view is Form form)
                {
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                }
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(_view.ServerAddress))
                throw new InvalidOperationException("Adres serwera jest wymagany.");

            if (string.IsNullOrWhiteSpace(_view.Login) || string.IsNullOrWhiteSpace(_view.Password))
                throw new InvalidOperationException("Login i has³o s¹ wymagane.");

            using var httpClient = _apiClientFactory.CreateHttpClient();
            var tokenClient = _apiClientFactory.CreateTokenClient(_view.ServerAddress, httpClient);

            // NSwag signature requires a body *and* username/password parameters.
            // Most servers ignore the duplicated args, but we provide both for compatibility.
            var request = new MpmTokenObtainRequest
            {
                Username = _view.Login,
                Password = _view.Password
            };

            var tokenPair = await tokenClient.CreateAsync(request, _view.Login, _view.Password).ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(tokenPair.Access) || string.IsNullOrWhiteSpace(tokenPair.Refresh))
                throw new InvalidOperationException("Token response contains empty access/refresh tokens.");

            _tokenStore.AccessToken = tokenPair.Access;
            _tokenStore.RefreshToken = tokenPair.Refresh;
        }
    }
}