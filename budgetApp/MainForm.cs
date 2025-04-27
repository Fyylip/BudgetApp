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
using budgetApp.DataBase;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;


namespace budgetApp
{
    public partial class MainForm : Form
    {
        private string _username;
        private int _userId;
        private CartesianChart lineChart;
        private PieChart pieChart;
        private CartesianChart barChartControl;
        private DatabaseHelper _dbHelper;

        //public MainForm(string email)
        //{
        //    // Konstruktor domy�lny
        //}

        public MainForm(string username, int userId)
        {
            InitializeComponent();
            _username = username;
            _userId = userId;
            _dbHelper = new DatabaseHelper();
            InitializeCharts();
        }

        public MainForm(DatabaseHelper dbHelper, int userId)
        {
            _dbHelper = dbHelper;
            _userId = userId;
        }

        public MainForm(int userId)
        {
            _userId = userId;
        }

        private void InitializeCharts()
        {
            // Pobierz dane dla wykresu ko�owego
            var (amounts, categories) = _dbHelper.GetPieChartData(_userId); // Pass the required 'userId' parameter

            // Wykres liniowy
            lineChart = new LineChart(_dbHelper).CreateLineChart(_userId); // Przekazanie _userId
            lineChart.Dock = DockStyle.Bottom;
            LineChartPanel.Controls.Add(lineChart);
            LineChartPanel.Resize += (s, e) => UpdateChartSize(lineChart, LineChartPanel);

            // Oszc�dno�ci
            var chartGenerator = new BarChart(BarChartPanel);

            // Pobierz dane z bazy danych dla cel�w oszcz�dno�ci
            var savingGoals = _dbHelper.GetSavingChartData(_userId);

            foreach (var goal in savingGoals)
            {
                // Oblicz procent osi�gni�cia celu
                int percent = (goal.GoalAmount > 0) ? (int)((goal.HowMuch / goal.GoalAmount) * 100) : 0;

                // Tw�rz panel post�pu dla ka�dego celu
                var panel = chartGenerator.CreateSavingsProgressPanel(goal.Label, percent, Color.Green);

                // Dodaj panel do kontenera
                BarChartPanel.Controls.Add(panel);
            }

            // Wykres ko�owy
            var pieChartViewModel = new PieChartViewModel();
            pieChart = pieChartViewModel.CreatePieChart(amounts, categories);
            pieChart.Dock = DockStyle.Top;
            PieChartPanel.Controls.Add(pieChart);
            PieChartPanel.Resize += (s, e) => UpdateChartSize(pieChart, PieChartPanel);

            // Pocz�tkowe ustawienia rozmiar�w
            UpdateChartSize(lineChart, LineChartPanel);
            UpdateChartSize(barChartControl, BarChartPanel);
            UpdateChartSize(pieChart, PieChartPanel);

            LoadAddictions();
        }


        private BarChart barChart;

        private void LoadPieChartData()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();

            // Przekazujemy userId, zak�adaj�c, �e masz t� zmienn� w MainForm
            var (amounts, categories) = dbHelper.GetPieChartData(_userId);

            // Przyk�ad: U�ycie danych do wy�wietlenia wykresu
            // Mo�esz tutaj przypisa� te dane do wykresu ko�owego
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"Kategoria: {categories[i]}, Kwota: {amounts[i]}");
            }
        }

        private void UpdateChartSize(Control chart, Panel panel)
        {
            if (chart == null || panel == null) return;

            chart.Height = (int)(panel.Height * 0.8);
            chart.Width = (int)(panel.Width * 0.95);
        }

        public void LoadTotalValue()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            decimal totalValue = dbHelper.GetTotalValue(_userId, "Wykres");

            if (totalValue != 0)
            {
                Total.Text = $"{totalValue}";
            }
            else
            {
                Total.Text = "Brak danych";
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Witaj, {_username}!";

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            try
            {
                con.Open();

                LoadTotalValue();

                string query2 = "SELECT Category, Amount FROM PieChartData WHERE UserId = @UserId";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@UserId", _userId);

                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    string categoryFromDb = reader["Category"]?.ToString() ?? string.Empty;
                    LegendData.Text += categoryFromDb + " ";
                }

                reader.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Pass the required 'userId' parameter to the AddPieChart constructor
            AddPieChart addPieChart = new AddPieChart(_userId);
            addPieChart.FormClosed += (s, args) => InitializeCharts(); // Od�wie�enie wykresu po zamkni�ciu okna
            addPieChart.Show();
        }

        private void SavingGoals_Click(object sender, EventArgs e)
        {
            SavingGoalsAdd addGoalForm = new SavingGoalsAdd(_userId);
            addGoalForm.Show();
            this.Hide();
        }

        private void AddExpense_Click(object sender, EventArgs e)
        {
            AddExpense addExpenseForm = new AddExpense(_userId);
            addExpenseForm.FormClosed += (s, args) => InitializeCharts(); // Od�wie�enie wykresu po zamkni�ciu okna
            addExpenseForm.Show();
        }

        private void LoadAddictions()
        {
            var addictions = _dbHelper.GetAddictionsWithAmounts(_userId);

            if (addictions.Count > 0)
            {
                Addictions.Text = string.Join(", ", addictions.Select(a => $"{a.Name} ({a.Amount} z�)"));
            }
            else
            {
                Addictions.Text = "Brak uzale�nie�.";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            EditAddictions editAddictionsForm = new EditAddictions(_dbHelper, _userId);
            editAddictionsForm.FormClosed += (s, args) => InitializeCharts(); // Od�wie�enie danych po zamkni�ciu okna
            editAddictionsForm.Show();
        }
    }
}

