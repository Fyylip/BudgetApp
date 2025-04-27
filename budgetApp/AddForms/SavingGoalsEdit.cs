using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using budgetApp.DataBase;

namespace budgetApp
{
    public partial class SavingGoalsEdit : Form
    {
        private int _userId; // Zmienna do przechowywania identyfikatora użytkownika

        public SavingGoalsEdit(int userId) // Konstruktor, który przyjmuje userId
        {
            InitializeComponent();
            _userId = userId;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            string label = txtSavingGoals.Text.Trim();
            string howMuchText = txtHowMuch.Text.Trim();

            if (string.IsNullOrEmpty(label) || string.IsNullOrEmpty(howMuchText))
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
                return;
            }

            if (!decimal.TryParse(howMuchText, out decimal amountToAdd))
            {
                MessageBox.Show("Podaj poprawną kwotę.");
                return;
            }

            try
            {
                DatabaseHelper.UpdateSavingGoalAmount(_userId, label, amountToAdd);
                MessageBox.Show("Kwota została dodana!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }
    }
}
