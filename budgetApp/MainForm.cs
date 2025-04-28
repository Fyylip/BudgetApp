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
        private BarChart barChart;
        private bool YerFlag = true;
        private bool WeekFlag = false;


        //public MainForm(string email)
        //{
        //    // Konstruktor domyœlny
        //}

        public MainForm(string username, int userId)
        {
            InitializeComponent();
            _username = username;
            _userId = userId;
            _dbHelper = new DatabaseHelper();
            InitializeCharts();
            InitializeSavingGoals();
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

        // To musi byæ oddzielnie bo inaczej siê dodaje z ka¿dym odsie¿eniem
        // W sumie nie wiem czy teraz musi byæ osobno ale nie ruszaj ju¿ bo dzia³a
        private void InitializeSavingGoals()
        {
            for (int i = BarChartPanel.Controls.Count - 1; i >= 0; i--)
            {
                Control control = BarChartPanel.Controls[i];
                if (control.Tag != null && control.Tag.ToString() == "SavingGoal")
                {
                    BarChartPanel.Controls.Remove(control);
                    control.Dispose();
                }
            }

            var chartGenerator = new BarChart(BarChartPanel);

            var savingGoals = _dbHelper.GetSavingChartData(_userId);

            foreach (var goal in savingGoals)
            {
                int percent = (goal.GoalAmount > 0) ? (int)((goal.HowMuch / goal.GoalAmount) * 100) : 0;

                var panel = chartGenerator.CreateSavingsProgressPanel(goal.Label, percent, Color.Green);

                panel.Tag = "SavingGoal";

                BarChartPanel.Controls.Add(panel);

                if (percent >= 100)
                {
                    _dbHelper.DeleteCompletedGoals(_userId);
                }
            }
        }
        private void InitializeCharts()
        {

            // Pobierz dane dla wykresu ko³owego
            var (amounts, categories) = _dbHelper.GetPieChartData(_userId); // Pass the required 'userId' parameter

            // Wykres liniowy
            if(YerFlag)
            {
                lineChart = new LineChart(_dbHelper).CreateLineChartYear(_userId);
                lineChart.Dock = DockStyle.Bottom;
                LineChartPanel.Controls.Add(lineChart);
                LineChartPanel.Resize += (s, e) => UpdateChartSize(lineChart, LineChartPanel);
            }

            else if (WeekFlag)
            {
                lineChart = new LineChart(_dbHelper).CreateLineChartWeek(_userId);
                lineChart.Dock = DockStyle.Bottom;
                LineChartPanel.Controls.Add(lineChart);
                LineChartPanel.Resize += (s, e) => UpdateChartSize(lineChart, LineChartPanel);
            }

            // Wykres ko³owy
            var pieChartViewModel = new PieChartViewModel();
            pieChart = pieChartViewModel.CreatePieChart(amounts, categories);
            pieChart.Dock = DockStyle.Top;
            PieChartPanel.Controls.Add(pieChart);
            PieChartPanel.Resize += (s, e) => UpdateChartSize(pieChart, PieChartPanel);

            // Pocz¹tkowe ustawienia rozmiarów
            UpdateChartSize(lineChart, LineChartPanel);
            UpdateChartSize(barChartControl, BarChartPanel);
            UpdateChartSize(pieChart, PieChartPanel);

            LoadAddictions();
            UpdateTotalLabel();
        }
        private void OpenSavingGoalsEdit()
        {
            // Tworzenie instancji SavingGoalsEdit i przekazywanie userId
            SavingGoalsEdit editForm = new SavingGoalsEdit(_userId);
            editForm.ShowDialog();
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

        public void LoadPieChartData()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            var (amounts, categories) = dbHelper.GetPieChartData(_userId);

            // Combine amounts and categories into a single list of tuples
            List<(string Category, decimal Amount)> pieChartData = categories
                .Zip(amounts, (category, amount) => (Category: category, Amount: amount))
                .ToList();

            //LegendData.Text = string.Join(" ", pieChartData.Select(data => data.Category));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Witaj, {_username}!";


            LoadTotalValue();
            LoadPieChartData();
        }

        // To jest chujowo ale nie mam czasu ju¿ 
        private void AddMoney_Click(object sender, EventArgs e)
        {
            // Pytanie o kwotê
            string input = Interaction.InputBox(
                "Dodaj pieni¹dze",
                "WprowadŸ kwotê",
                "0"
            );
            // Nie da³em tego do Helpera bo nie dzi³a chuj wie czemu te¿ nie ruszaj
            if (decimal.TryParse(input, out decimal amount) && amount > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

                try
                {
                    con.Open();

                    // Sprawdzenie, czy rekord ju¿ istnieje
                    string checkQuery = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@UserId", _userId);
                    checkCmd.Parameters.AddWithValue("@Label", "Wykres");

                    var existingValue = checkCmd.ExecuteScalar();

                    if (existingValue != null)
                    {
                        // Jeœli rekord istnieje, zaktualizuj wartoœæ
                        decimal currentValue = (decimal)existingValue;
                        decimal newValue = currentValue + amount;

                        string updateQuery = "UPDATE Total SET Value = @Value, Date = @Date WHERE UserId = @UserId AND Label = @Label";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@Value", newValue);
                        updateCmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        updateCmd.Parameters.AddWithValue("@UserId", _userId);
                        updateCmd.Parameters.AddWithValue("@Label", "Wykres");

                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Pieni¹dze dodane i wartoœæ zaktualizowana!");
                    }
                    else
                    {
                        // Jeœli rekord nie istnieje, dodaj nowy
                        string insertQuery = "INSERT INTO Total (UserId, Label, Value, Date) VALUES (@UserId, @Label, @Value, @Date)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@UserId", _userId);
                        insertCmd.Parameters.AddWithValue("@Label", "Wykres");
                        insertCmd.Parameters.AddWithValue("@Value", amount);
                        insertCmd.Parameters.AddWithValue("@Date", DateTime.Now);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Pieni¹dze dodane!");
                    }

                    // Po dodaniu lub zaktualizowaniu danych, odœwie¿ etykietê
                    UpdateTotalLabel();
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
            else
            {
                MessageBox.Show("Nieprawid³owa kwota.");
            }
        }

        //private void UpdateTotalLabel(SqlConnection con)
        //{
        //    try
        //    {
        //        // Pobierz zaktualizowan¹ wartoœæ z bazy danych
        //        string query = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@UserId", _userId);
        //        cmd.Parameters.AddWithValue("@Label", "Wykres");

        //        var result = cmd.ExecuteScalar();

        //        if (result != null)
        //        {
        //            decimal totalValue = (decimal)result;
        //            Total.Text = $"{totalValue}"; // Przypisz wynik do label
        //        }
        //        else
        //        {
        //            Total.Text = "Brak danych"; // Jeœli nie znaleziono rekordu
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("B³¹d podczas aktualizacji etykiety: " + ex.Message);
        //    }
        //}

        private void UpdateTotalLabel()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            decimal totalValue = dbHelper.GetTotalValue(_userId, "Wykres"); // Wykres bo bo tak nie wiem czemu nie ruszaj tego

            Total.Text = $"{totalValue}";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPieChart addPieChart = new AddPieChart(_userId);
            addPieChart.FormClosed += (s, args) => InitializeCharts(); // Odœwie¿enie wykresu po zamkniêciu okna
            addPieChart.Show();
        }

        private void SavingGoals_Click(object sender, EventArgs e)
        {
            SavingGoalsAdd addGoalForm = new SavingGoalsAdd(_userId);
            addGoalForm.Show();
            addGoalForm.FormClosed += (s, args) => InitializeSavingGoals(); // Odœwie¿enie wykresu po zamkniêciu okna
        }

        private void AddExpense_Click(object sender, EventArgs e)
        {
            AddExpense addExpenseForm = new AddExpense(_userId);
            addExpenseForm.FormClosed += (s, args) => LoadAddictions(); // Odœwie¿enie wykresu po zamkniêciu okna
            addExpenseForm.Show();
        }
        // Name mog¹ byæ pojebane bo siê spieszy³em
        private void LoadAddictions()
        {
            var addictions = _dbHelper.GetAddictionsWithAmounts(_userId);

            if (addictions.Count > 0)
            {
                Addictions.Text = string.Join("\n \n", addictions.Select(a => $"{a.Name} ({a.Amount} z³)"));
            }
            else
            {
                Addictions.Text = "Brak uzale¿nieñ.";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            EditAddictions editAddictionsForm = new EditAddictions(_dbHelper, _userId);
            editAddictionsForm.FormClosed += (s, args) => InitializeCharts(); // Odœwie¿enie danych po zamkniêciu okna
            editAddictionsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SavingGoalsEdit editGoalsForm = new SavingGoalsEdit(_userId);
            editGoalsForm.FormClosed += (s, args) => InitializeSavingGoals(); // Odœwie¿enie danych po zamkniêciu okna
            editGoalsForm.Show();

        }
        private void btnLineYer_Click(object sender, EventArgs e)
        {
            YerFlag = true;
            WeekFlag = false;
            RefreshLineChart();
        }

        private void btnYerMonth_Click(object sender, EventArgs e)
        {
            YerFlag = false;
            WeekFlag = true;
            RefreshLineChart();
        }
        private void RefreshLineChart()
        {
            // Usuwasz stary wykres
            if (lineChart != null)
            {
                LineChartPanel.Controls.Remove(lineChart);
                lineChart.Dispose();
            }

            // Tworzysz nowy wed³ug flag
            if (YerFlag)
                lineChart = new LineChart(_dbHelper).CreateLineChartYear(_userId);
            else if (WeekFlag)
                lineChart = new LineChart(_dbHelper).CreateLineChartWeek(_userId);

            if (lineChart != null)
            {
                lineChart.Dock = DockStyle.Bottom;
                LineChartPanel.Controls.Add(lineChart);
                UpdateChartSize(lineChart, LineChartPanel);
            }
        }
    }
}

