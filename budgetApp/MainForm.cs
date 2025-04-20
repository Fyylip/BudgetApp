using budgetApp.Charts;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModelsSamples.Pies.Basic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

namespace budgetApp
{
    public partial class MainForm : Form
    {
        private string _username;
        private int _userId;
        private CartesianChart lineChart;
        private PieChart pieChart;
        private CartesianChart barChartControl;

        public MainForm()
        {
            // Konstruktor domy�lny
        }

        public MainForm(string username, int userId)
        {
            InitializeComponent();
            _username = username;
            _userId = userId;

            // Inicjalizacja wykres�w
            InitializeCharts();
        }

        private void InitializeCharts()
        {
            // Wykres liniowy
            lineChart = new LineChart().CreateLineChart();
            lineChart.Dock = DockStyle.Bottom;
            LineChartPanel.Controls.Add(lineChart);
            LineChartPanel.Resize += (s, e) => UpdateChartSize(lineChart, LineChartPanel);

            // Wykres s�upkowy
            barChartControl = new BarChart().CreateBarChart();
            barChartControl.Dock = DockStyle.Bottom;
            BarChartPanel.Controls.Add(barChartControl);
            BarChartPanel.Resize += (s, e) => UpdateChartSize(barChartControl, BarChartPanel);

            // Wykres ko�owy
            var pieChartViewModel = new PieChartViewModel();
            pieChart = pieChartViewModel.CreatePieChart();
            pieChart.Dock = DockStyle.Top;
            PieChartPanel.Controls.Add(pieChart);
            PieChartPanel.Resize += (s, e) => UpdateChartSize(pieChart, PieChartPanel);

            // Pocz�tkowe ustawienia rozmiar�w
            UpdateChartSize(lineChart, LineChartPanel);
            UpdateChartSize(barChartControl, BarChartPanel);
            UpdateChartSize(pieChart, PieChartPanel);
        }

        private void UpdateChartSize(Control chart, Panel panel)
        {
            if (chart == null || panel == null) return;

            chart.Height = (int)(panel.Height * 0.8);
            chart.Width = (int)(panel.Width * 0.95);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Witaj, {_username}!";

            // Pobierz warto�� z bazy danych i przypisz j� do lblTotal
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            try
            {
                con.Open();

                // Sprawd� warto�� z tabeli Total
                string query = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", _userId);
                cmd.Parameters.AddWithValue("@Label", "Wykres"); // Zamie� na odpowiedni� etykiet�

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    decimal totalValue = (decimal)result;
                    Total.Text = $"{totalValue}"; // Przypisz wynik do label
                }
                else
                {
                    Total.Text = "Brak danych"; // Je�li nie znaleziono rekordu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B��d: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddMoney_Click(object sender, EventArgs e)
        {
            // Pytanie o kwot�
            string input = Interaction.InputBox(
                "Dodaj pieni�dze",
                "Wprowad� kwot�",
                "0"
            );

            if (decimal.TryParse(input, out decimal amount) && amount > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

                try
                {
                    con.Open();

                    // Sprawdzenie, czy rekord ju� istnieje
                    string checkQuery = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@UserId", _userId);
                    checkCmd.Parameters.AddWithValue("@Label", "Wykres"); // Zamie� na odpowiedni� etykiet�

                    var existingValue = checkCmd.ExecuteScalar();

                    if (existingValue != null)
                    {
                        // Je�li rekord istnieje, zaktualizuj warto��
                        decimal currentValue = (decimal)existingValue;
                        decimal newValue = currentValue + amount;

                        string updateQuery = "UPDATE Total SET Value = @Value, Date = @Date WHERE UserId = @UserId AND Label = @Label";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@Value", newValue);
                        updateCmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        updateCmd.Parameters.AddWithValue("@UserId", _userId);
                        updateCmd.Parameters.AddWithValue("@Label", "Wykres");

                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Pieni�dze dodane i warto�� zaktualizowana!");
                    }
                    else
                    {
                        // Je�li rekord nie istnieje, dodaj nowy
                        string insertQuery = "INSERT INTO Total (UserId, Label, Value, Date) VALUES (@UserId, @Label, @Value, @Date)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@UserId", _userId);
                        insertCmd.Parameters.AddWithValue("@Label", "Wykres"); // Zamie� na odpowiedni� etykiet�
                        insertCmd.Parameters.AddWithValue("@Value", amount);
                        insertCmd.Parameters.AddWithValue("@Date", DateTime.Now);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Pieni�dze dodane!");
                    }

                    // Po dodaniu lub zaktualizowaniu danych, od�wie� etykiet�
                    UpdateTotalLabel(con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B��d: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Nieprawid�owa kwota.");
            }
        }

        private void UpdateTotalLabel(SqlConnection con)
        {
            try
            {
                // Pobierz zaktualizowan� warto�� z bazy danych
                string query = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", _userId);
                cmd.Parameters.AddWithValue("@Label", "Wykres");

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    decimal totalValue = (decimal)result;
                    Total.Text = $"{totalValue}"; // Przypisz wynik do label
                }
                else
                {
                    Total.Text = "Brak danych"; // Je�li nie znaleziono rekordu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B��d podczas aktualizacji etykiety: " + ex.Message);
            }
        }



    }
}

