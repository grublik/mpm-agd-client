namespace MpmClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dockPanel.Theme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            var testModule = new Modules.Users.Test();
            testModule.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);

        }
    }
}
