using MpmClient.Core;
using MpmClient.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MpmClient.Modules.Users
{
    internal class Base : IAppModule
    {
        private const string MENU_ACTION_EMPLOYEE_LIST = "/users/employee/list";

        private Presenters.EmployeeListPresenter? _employeeListPresenter = null;

        public event Action<DocumentDockContent>? DockContent;
        public Dictionary<string, EventHandler> GetModuleMenuActions()
        {
            return new Dictionary<string, EventHandler>()
            {
                { MENU_ACTION_EMPLOYEE_LIST, OnEmployeeList }
            };
        }
        
        private void OnEmployeeList(object? sender, EventArgs e)
        {
            MessageBox.Show("Employee List clicked");
            if (_employeeListPresenter == null)
            {
                _employeeListPresenter = new Presenters.EmployeeListPresenter(new Views.EmployeeListForm());
            }

            DockContent?.Invoke(_employeeListPresenter.GetView() as DocumentDockContent);
        }
    }
}