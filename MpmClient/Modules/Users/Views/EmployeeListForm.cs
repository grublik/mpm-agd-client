using MpmClient.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MpmClient.Modules.Users.Views.Interface;

namespace MpmClient.Modules.Users.Views
{
    public partial class EmployeeListForm : DocumentDockContent, IEmployeeList
    {
        public EmployeeListForm()
        {
            InitializeComponent();
        }

        public void SetEmployeesData(object data)
        {
            throw new NotImplementedException();
        }
    }
}
