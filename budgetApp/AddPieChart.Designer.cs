namespace budgetApp
{
    partial class AddPieChart
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
            MoneyInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            DescriptionInput = new TextBox();
            SuspendLayout();
            // 
            // MoneyInput
            // 
            MoneyInput.Location = new Point(205, 59);
            MoneyInput.Name = "MoneyInput";
            MoneyInput.Size = new Size(100, 23);
            MoneyInput.TabIndex = 0;
            MoneyInput.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(116, 59);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 1;
            label1.Text = "how much";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(116, 100);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 3;
            label2.Text = "description";
            // 
            // DescriptionInput
            // 
            DescriptionInput.Location = new Point(205, 100);
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.Size = new Size(100, 23);
            DescriptionInput.TabIndex = 2;
            // 
            // AddPieChart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(365, 213);
            Controls.Add(label2);
            Controls.Add(DescriptionInput);
            Controls.Add(label1);
            Controls.Add(MoneyInput);
            Name = "AddPieChart";
            Text = "AddMoney";
            Load += this.AddPieChart_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MoneyInput;
        private Label label1;
        private Label label2;
        private TextBox DescriptionInput;
    }
}