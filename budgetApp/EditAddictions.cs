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
    public partial class EditAddictions : Form
    {
        private DatabaseHelper _dbHelper;
        private int _userId;
        public EditAddictions(DatabaseHelper dbHelper, int userId)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            _userId = userId;
        }

        private void EdidAddition_Click(object sender, EventArgs e)
        {
            string addictionName = txtNameAddition.Text.Trim();
            if (string.IsNullOrEmpty(addictionName))
            {
                MessageBox.Show("Podaj nazwę uzależnienia.");
                return;
            }

            if (!decimal.TryParse(AdditionSpend.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Podaj prawidłową kwotę.");
                return;
            }

            _dbHelper.UpdateAddictionAmount(_userId, addictionName, amount);
            MessageBox.Show("Kwota została dodana!");
            this.Close();
        }
    }
}
