namespace MpmClient.Modules.Users.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.Button btnLogin;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtServerAddress = new TextBox();
            lblLogin = new Label();
            lblPassword = new Label();
            lblServerAddress = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLogin.Location = new Point(206, 24);
            txtLogin.Margin = new Padding(5, 6, 5, 6);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(389, 35);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(206, 82);
            txtPassword.Margin = new Padding(5, 6, 5, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(389, 35);
            txtPassword.TabIndex = 3;
            // 
            // txtServerAddress
            // 
            txtServerAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServerAddress.Location = new Point(206, 140);
            txtServerAddress.Margin = new Padding(5, 6, 5, 6);
            txtServerAddress.Name = "txtServerAddress";
            txtServerAddress.Size = new Size(389, 35);
            txtServerAddress.TabIndex = 5;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(21, 30);
            lblLogin.Margin = new Padding(5, 0, 5, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(64, 30);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Login";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(21, 88);
            lblPassword.Margin = new Padding(5, 0, 5, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 30);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Hasło";
            // 
            // lblServerAddress
            // 
            lblServerAddress.AutoSize = true;
            lblServerAddress.Location = new Point(21, 146);
            lblServerAddress.Margin = new Padding(5, 0, 5, 0);
            lblServerAddress.Name = "lblServerAddress";
            lblServerAddress.Size = new Size(140, 30);
            lblServerAddress.TabIndex = 4;
            lblServerAddress.Text = "Adres serwera";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogin.Location = new Point(469, 198);
            btnLogin.Margin = new Padding(5, 6, 5, 6);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(129, 46);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Zaloguj się";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 268);
            Controls.Add(btnLogin);
            Controls.Add(txtServerAddress);
            Controls.Add(lblServerAddress);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtLogin);
            Controls.Add(lblLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logowanie do MpmClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}