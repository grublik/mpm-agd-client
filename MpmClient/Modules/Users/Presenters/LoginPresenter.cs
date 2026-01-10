using System;
using MpmClient.Modules.Users.Views;

namespace MpmClient.Modules.Users.Presenters
{
    internal class LoginPresenter
    {
        private readonly ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            _view = view;

            _view.SetServerAddress(Settings.Default.MpmApiServerAddr);
            _view.LoginAttempted += OnLoginAttempted;
        }

        private void OnLoginAttempted(object? sender, EventArgs e)
        {
            if (Authenticate(_view.Login, _view.Password, _view.ServerAddress))
            {
                Settings.Default.MpmApiServerAddr = _view.ServerAddress;
                Settings.Default.Save();
            }
            else
            {
                _view.ShowError("Nie poprawny login lub has³o. Spróbuj ponownie.");
            }
        }

        private bool Authenticate(string login, string password, string serverAddress)
        {
            // TODO: Replace with real authentication logic
            return !string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password);
        }
    }
}