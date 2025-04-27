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
using Microsoft.VisualBasic.ApplicationServices;

namespace budgetApp
{
    public partial class AddExpense: Form
    {
        private int _userId;
        private DatabaseHelper _dbHelper;
        public AddExpense(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _dbHelper = new DatabaseHelper();
        }

        private void btnAddAddiction_Click(object sender, EventArgs e)
        {
            string addictionName = txtExpense.Text.Trim();

            if (string.IsNullOrEmpty(addictionName))
            {
                MessageBox.Show("Wprowadź nazwę nałogu!");
                return;
            }

            decimal amount = 0; // Można ustawić kwotę na 0 lub dodać pole, w którym użytkownik wpisuje kwotę.

            try
            {
                // Wywołanie metody w DatabaseHelper do dodania nałogu
                _dbHelper.AddAddiction(_userId, addictionName, amount);
                MessageBox.Show("Nałóg został dodany!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania nałogu: " + ex.Message);
            }
        }
    }
}
