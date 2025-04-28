using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LoginSystem
{
    public partial class Rejestr : Form
    {
        public Rejestr()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtPassword2.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string password2 = txtPassword2.Text.Trim();

            if (email == "" || password == "" || password2 == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
                return;
            }

            if (password != password2)
            {
                MessageBox.Show("Hasła nie są takie same.");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Hasło musi zawierać co najmniej 6 znaków, dużą literę i znak specjalny.");
                return;
            }

            string hashedPassword = HashPassword(password);

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            try
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE userName = @username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@username", email);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Użytkownik już istnieje.");
                }
                else
                {
                    string insertQuery = "INSERT INTO Users (userName, pasword) VALUES (@username, @password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@username", email);
                    insertCmd.Parameters.AddWithValue("@password", hashedPassword);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Rejestracja zakończona sukcesem!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*\W).{6,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPassword2.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPassword2.PasswordChar = '*';
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
    }
}
    