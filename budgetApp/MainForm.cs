using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace budgetApp
{
    public partial class MainForm : Form
    {
        private string _username;
        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Witaj, {_username}!";
        }
    }
}
