using MpmClient.Modules.Main.Views.Interface;

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

        public MenuStrip MenuStrip => menuStripMain;

        public bool ShowLoginView()
        {
            // Show the login view
            if (_loginView.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Zalogowano pomyœlnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Logowanie nie powiod³o siê lub zosta³o anulowane.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void ShowDockingContent(Core.DocumentDockContent dock)
        {
            try
            {
                dock.Show(dockPanel);
            }
            catch (Exception e)
            {
                // Log the exception or show a message box
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas otwierania zawartoœci: {e.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
