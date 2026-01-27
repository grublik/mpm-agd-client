using MpmClient.Core;
using MpmClient.Core.Interface;
using MpmClient.Modules.Main.Views.Interface;
using MpmClient.Modules.Users.Views.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace MpmClient.Modules.Main.Presenters
{
    internal class MainFormPresenter
    {
        private readonly IMainFormView _mainView;
        private readonly Dictionary<ModuleFactory.ApplicationModules, IAppModule> _appModules;
        private readonly Common.MenuManager _menuManager;

        //private readonly ILoginView _loginView;

        public MainFormPresenter(IMainFormView mainView, ILoginView loginView)
        {
            _mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            _appModules = new Dictionary<ModuleFactory.ApplicationModules, IAppModule>();
            _menuManager = new Common.MenuManager(_mainView.MenuStrip);

            //_loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            _mainView.Load += OnViewLoad;
        }
        private void OnViewLoad(object? sender, EventArgs e)
        {
            if (_mainView.ShowLoginView())
            {
                var availableModules = Enum.GetValues(typeof(ModuleFactory.ApplicationModules)).Cast<ModuleFactory.ApplicationModules>();

                foreach (var module in availableModules)
                {
                    var moduleObj = ModuleFactory.CreateModule(module); 
                    moduleObj.DockContent += ShowDockingContent;
                    _menuManager.AddActionEntries(moduleObj.GetModuleMenuActions());
                    _appModules.Add(module, moduleObj);
                }

                _menuManager.GenerateMenuFromActions();
            }
            else
            {
            #if !DEBUG
                // Close the main application
                Environment.Exit(0);
            #endif
            }
        }

        private void ShowDockingContent(DocumentDockContent dock)
        {
            try
            {
                //if delegate isnt subscribed
                //if (dock.ShowAppProgressBar == null)
                //    dock.ShowAppProgressBar += ToolStripProgressBarChangeVisibility;

                _mainView.ShowDockingContent(dock);
            }
            catch
            {
                return;
            }
        }
    }
}
