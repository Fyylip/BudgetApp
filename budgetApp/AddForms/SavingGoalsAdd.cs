using System;
using System.Windows.Forms;
using budgetApp.DataBase;

namespace budgetApp
{
    public partial class SavingGoalsAdd : Form
    {
        private int _userId;
        private DatabaseHelper _dbHelper;

        public SavingGoalsAdd(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _dbHelper = new DatabaseHelper(); // Inicjalizuj raz
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text.Trim();
            decimal goalAmount = 0;
            decimal howMuch = 0;

            if (!decimal.TryParse(txtGoal.Text, out goalAmount) || goalAmount <= 0)
            {
                MessageBox.Show("Wprowadź prawidłową kwotę celu!");
                return;
            }

            if (!decimal.TryParse(numHowMuch.Text, out howMuch) || howMuch < 0)
            {
                MessageBox.Show("Wprowadź prawidłową wartość wpłaty!");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Wprowadź opis celu!");
                return;
            }

            try
            {
                _dbHelper.UpdateTotalRecord(_userId, goalAmount);
                _dbHelper.AddSavingGoal(_userId, description, goalAmount, howMuch);

                MessageBox.Show("Cel został dodany!");
                MainForm mainForm = new MainForm("DefaultUsername", _userId);
                mainForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania celu: " + ex.Message);
            }
        }
    }
}
