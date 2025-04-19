using budgetApp.Charts;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModelsSamples.Pies.Basic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace budgetApp
{
    public partial class MainForm : Form
    {
        private string _username;
        private CartesianChart _cartesianChart;

        public MainForm()
        {
            // Konstruktor domyœlny
        }

        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;

            // Inicjalizacja wykresu
            InitializeCharts();
        }
        private void InitializeCharts()
        {
            // Wykres liniowy
            var lineChart = new LineChart().CreateLineChart();
            lineChart.Dock = DockStyle.Fill;
            LineChartPanel.Controls.Add(lineChart);

            // Wykres s³upkowy (Do poprawy)
            var barChart = new BarChart().CreateBarChart();
            barChart.Dock = DockStyle.Fill;
            BarChartPanel.Controls.Add(barChart);

            // Wykres ko³owy
            var pieChartViewModel = new PieChartViewModel();
            var pieChart = pieChartViewModel.CreatePieChart();
            pieChart.Dock = DockStyle.Fill;
            PieChartPanel.Controls.Add(pieChart);

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Witaj, {_username}!";
        }
    }
}