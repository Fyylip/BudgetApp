using System;
using System.Windows.Forms;
using budgetApp.DataBase;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace budgetApp
{
    public partial class AddPieChart : Form
    {
        private int _userId;
        private DatabaseHelper _dbHelper;

        public AddPieChart(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _dbHelper = new DatabaseHelper();
        }

        private string GetSelectedCategory()
        {
            if (radioFood.Checked)
                return "Food";
            else if (radioMustHave.Checked)
                return "Must have";
            else if (radioPleasures.Checked)
                return "Pleasures";
            else
                return string.Empty; // Zwracamy pusty ciąg, gdy żadna kategoria nie jest wybrana
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string category = GetSelectedCategory();
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Wybierz kategorię.");
                return;
            }

            if (!decimal.TryParse(AmountInput.Text.Replace(',', '.'), out decimal amount))
            {
                MessageBox.Show("Nieprawidłowa kwota.");
                return;
            }

            try
            {
                _dbHelper.UpdateTotalRecord(_userId, amount); // Moved here to ensure 'amount' is defined
                if (_dbHelper.RecordExists(_userId, category))
                {
                    // Jeśli rekord istnieje, zaktualizuj go
                    _dbHelper.UpdateRecord(_userId, category, amount);
                    MessageBox.Show("Kwota zaktualizowana w wykresie kołowym!");
                }
                else
                {
                    // Jeśli rekord nie istnieje, dodaj nowy
                    _dbHelper.InsertRecord(_userId, category, amount);
                    MessageBox.Show("Dane dodane do wykresu kołowego!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string category = GetSelectedCategory();
            if (category == "Unknown")
            {
                MessageBox.Show("Wybierz kategorię do edycji.");
                return;
            }

            if (!decimal.TryParse(AmountInput.Text.Replace(',', '.'), out decimal newAmount))
            {
                MessageBox.Show("Nieprawidłowa kwota.");
                return;
            }

            try
            {
                if (_dbHelper.RecordExists(_userId, category))
                {
                    _dbHelper.UpdateRecord(_userId, category, newAmount);
                    MessageBox.Show("Kwota została zaktualizowana.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie znaleziono wpisu dla tej kategorii.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }
    }

}
