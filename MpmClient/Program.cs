using MpmClient.Api;
using MpmClient.Modules.Main.Presenters;
using MpmClient.Modules.Main.Views;
using MpmClient.Modules.Users.Presenters;
using MpmClient.Modules.Users.Views;
using MpmClient.Security;

namespace MpmClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var tokenStore = new TokenStore();

            // Read base URL lazily (always current, after login saves it).
            var apiClientFactory = new ApiClientFactory(
                tokenStore,
                () => Settings.Default.MpmApiServerAddr);

            var loginForm = new LoginForm();
            loginForm.Tag = new LoginPresenter(loginForm, apiClientFactory, tokenStore);

            var mainForm = new MainForm(loginForm);
            mainForm.Tag = new MainFormPresenter(mainForm, loginForm);

            Application.Run(mainForm);
        }
    }
}