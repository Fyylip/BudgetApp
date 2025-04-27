namespace budgetApp
{
    partial class SavingGoalsEdit
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
            HowMuch = new Label();
            txtHowMuch = new TextBox();
            Edit = new Button();
            label1 = new Label();
            txtSavingGoals = new TextBox();
            SuspendLayout();
            // 
            // HowMuch
            // 
            HowMuch.AutoSize = true;
            HowMuch.Font = new Font("Segoe UI", 12F);
            HowMuch.ForeColor = Color.White;
            HowMuch.Location = new Point(173, 88);
            HowMuch.Name = "HowMuch";
            HowMuch.Size = new Size(81, 21);
            HowMuch.TabIndex = 0;
            HowMuch.Text = "HowMuch";
            // 
            // txtHowMuch
            // 
            txtHowMuch.Location = new Point(286, 88);
            txtHowMuch.Name = "txtHowMuch";
            txtHowMuch.Size = new Size(100, 23);
            txtHowMuch.TabIndex = 1;
            // 
            // Edit
            // 
            Edit.Location = new Point(286, 133);
            Edit.Name = "Edit";
            Edit.Size = new Size(75, 23);
            Edit.TabIndex = 2;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(113, 37);
            label1.Name = "label1";
            label1.Size = new Size(141, 21);
            label1.TabIndex = 3;
            label1.Text = "Saving goals name";
            // 
            // txtSavingGoals
            // 
            txtSavingGoals.Location = new Point(286, 35);
            txtSavingGoals.Name = "txtSavingGoals";
            txtSavingGoals.Size = new Size(100, 23);
            txtSavingGoals.TabIndex = 4;
            // 
            // SavingGoalsEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(408, 193);
            Controls.Add(txtSavingGoals);
            Controls.Add(label1);
            Controls.Add(Edit);
            Controls.Add(txtHowMuch);
            Controls.Add(HowMuch);
            Name = "SavingGoalsEdit";
            Text = "SavingGoalsEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HowMuch;
        private TextBox txtHowMuch;
        private Button Edit;
        private Label label1;
        private TextBox txtSavingGoals;
    }
}