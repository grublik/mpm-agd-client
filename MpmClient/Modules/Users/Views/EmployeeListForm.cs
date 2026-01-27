using MpmClient.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MpmClient.Modules.Users.Views.Interface;
using MpmClient.Api;

namespace MpmClient.Modules.Users.Views
{
    public partial class EmployeeListForm : DocumentDockContent, IEmployeeList
    {
        public EmployeeListForm()
        {
            InitializeComponent();

            this.Load += (s, e) => LoadEmployeeList(s, e);
        }

        public event EventHandler LoadEmployeeList = delegate { };
        public void SetEmployeesData(ICollection<UserEmployee> data)
        {
            dataGridView.DataSource = data;
        }
    }
}
