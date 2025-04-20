using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace budgetApp
{
    public partial class AddPieChart : Form
    {
        private int _userId;

        public AddPieChart(int userId)
        {
            InitializeComponent();
            _userId = userId;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ',')) // przecinek dla dziesiętnych
            {
                e.Handled = true;
            }

            // Tylko jeden przecinek
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void AddPieChart_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string query = "SELECT Value FROM PieChart WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", _userId); // <<< Ustawiamy userId

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    decimal value = Convert.ToDecimal(result);
                }
                else
                {
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

    }
}
