namespace MpmClient.Modules.Main.Views
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly Form _loginView;

        public MainForm(Form loginView)
        {
            _loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            InitializeComponent();
        }

        public void ShowLoginView()
        {
            // Show the login view
            if (_loginView.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Zalogowano pomyœlnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Logowanie nie powiod³o siê lub zosta³o anulowane.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
