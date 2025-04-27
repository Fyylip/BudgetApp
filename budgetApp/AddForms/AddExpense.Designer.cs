namespace budgetApp
{
    partial class AddExpense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtExpense = new TextBox();
            AddAddiction = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(212, 41);
            label1.Name = "label1";
            label1.Size = new Size(66, 21);
            label1.TabIndex = 0;
            label1.Text = "Expense";
            // 
            // txtExpense
            // 
            txtExpense.Location = new Point(302, 41);
            txtExpense.Name = "txtExpense";
            txtExpense.Size = new Size(100, 23);
            txtExpense.TabIndex = 1;
            // 
            // AddAddiction
            // 
            AddAddiction.Location = new Point(302, 103);
            AddAddiction.Name = "AddAddiction";
            AddAddiction.Size = new Size(75, 23);
            AddAddiction.TabIndex = 2;
            AddAddiction.Text = "Add";
            AddAddiction.UseVisualStyleBackColor = true;
            AddAddiction.Click += btnAddAddiction_Click;
            // 
            // AddExpense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(414, 207);
            Controls.Add(AddAddiction);
            Controls.Add(txtExpense);
            Controls.Add(label1);
            Name = "AddExpense";
            Text = "AddExpense";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtExpense;
        private Button AddAddiction;
    }
}