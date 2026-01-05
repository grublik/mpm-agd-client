using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MpmClient.Modules.Users
{
    public partial class Test : DockContent
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://127.0.0.1:8000/");
            Api.UsersClient usersClient = new Api.UsersClient(httpClient);


            usersClient.ListAsync().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    Console.WriteLine("Error fetching users: " + task.Exception.Message);
                    MessageBox.Show("Error fetching users: " + task.Exception.Message);
                    return;
                }
                var users = task.Result;

                Invoke((MethodInvoker)delegate
                {
                    dataGridViewUsers.DataSource = users;
                });

                Console.WriteLine(users);
            });
        }
    }
}
