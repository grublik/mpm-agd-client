using System;
using System.Collections.Generic;
using System.Text;
using MpmClient.Modules.Main.Views;
using MpmClient.Modules.Users.Views;

namespace MpmClient.Modules.Main.Presenters
{
    internal class MainFormPresenter
    {
        private readonly IMainFormView _mainView;
        //private readonly ILoginView _loginView;

        public MainFormPresenter(IMainFormView mainView, ILoginView loginView)
        {
            _mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            //_loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            _mainView.Load += OnViewLoad;
        }
        private void OnViewLoad(object? sender, EventArgs e)
        {
            _mainView.ShowLoginView();
        }
    }
}
