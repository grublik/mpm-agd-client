using System;

namespace MpmClient.Modules.Users.Views.Interface
{
    internal interface ILoginView
    {
        event EventHandler LoginAttempted;

        string Login { get; }
        string Password { get; }
        string ServerAddress { get; set; }

        void SetServerAddress(string ipAddress);
        void ShowError(string message);
    }
}