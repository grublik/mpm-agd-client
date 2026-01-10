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
            _loginView.ShowDialog();
        }
    }
}
