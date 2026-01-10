using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MpmClient.Modules.Users.Views
{
    public partial class LoginForm : Form, ILoginView
    {
        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += (s, e) => LoginAttempted(this, EventArgs.Empty);
        }

        public event EventHandler LoginAttempted = delegate { };
        public string Login => txtLogin.Text;

        public string Password => txtPassword.Text;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string ServerAddress
        {
            get => txtServerAddress.Text;
            set => txtServerAddress.Text = value;
        }

        public void SetServerAddress(string ipAddress)
        {
            txtServerAddress.Text = ipAddress;
        }   

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd podczas logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
