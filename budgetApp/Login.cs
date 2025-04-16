using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using budgetApp;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Uzupe³nij wszystkie pola.");
                return;
            }

            string hashedPassword = HashPassword(password);

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE userName=@username AND pasword=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    //MessageBox.Show("Zalogowano pomyœlnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm(email);
                    mainForm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub has³o.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                    result.Append(b.ToString("x2"));
                return result.ToString();
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    txtUserName.Text = "Login";
        //    txtPassword.Text = "Password";
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rejestr rejestr = new Rejestr();
            rejestr.Show();
            this.Hide();
        }
    }
}
