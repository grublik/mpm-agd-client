using System;
using System.Collections.Generic;
using System.Text;
using MpmClient.Modules.Users.Views.Interface;

namespace MpmClient.Modules.Users.Presenters
{
    internal class EmployeeListPresenter
    {
        private readonly IEmployeeList _view;

        public EmployeeListPresenter(IEmployeeList view)
        {
            _view = view;
        }

        public IEmployeeList GetView()
        {
            return _view;
        }


    }
}
