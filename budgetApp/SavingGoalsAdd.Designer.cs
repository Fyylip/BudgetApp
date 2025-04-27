namespace budgetApp
{
    partial class SavingGoalsAdd
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
            label2 = new Label();
            txtDescription = new TextBox();
            numHowMuch = new TextBox();
            Add = new Button();
            txtGoal = new TextBox();
            wefwefwef = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(193, 47);
            label1.Name = "label1";
            label1.Size = new Size(89, 21);
            label1.TabIndex = 0;
            label1.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(193, 101);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 1;
            label2.Text = "How much";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(295, 49);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(100, 23);
            txtDescription.TabIndex = 2;
            // 
            // numHowMuch
            // 
            numHowMuch.Location = new Point(295, 101);
            numHowMuch.Name = "numHowMuch";
            numHowMuch.Size = new Size(100, 23);
            numHowMuch.TabIndex = 3;
            // 
            // Add
            // 
            Add.Location = new Point(203, 195);
            Add.Name = "Add";
            Add.Size = new Size(75, 23);
            Add.TabIndex = 4;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // txtGoal
            // 
            txtGoal.Location = new Point(295, 148);
            txtGoal.Name = "txtGoal";
            txtGoal.Size = new Size(100, 23);
            txtGoal.TabIndex = 5;
            // 
            // wefwefwef
            // 
            wefwefwef.AutoSize = true;
            wefwefwef.Font = new Font("Segoe UI", 12F);
            wefwefwef.ForeColor = Color.White;
            wefwefwef.Location = new Point(193, 148);
            wefwefwef.Name = "wefwefwef";
            wefwefwef.Size = new Size(42, 21);
            wefwefwef.TabIndex = 6;
            wefwefwef.Text = "Goal";
            // 
            // SavingGoalsAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(417, 230);
            Controls.Add(wefwefwef);
            Controls.Add(txtGoal);
            Controls.Add(Add);
            Controls.Add(numHowMuch);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SavingGoalsAdd";
            Text = "SavingGoalsAdd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDescription;
        private TextBox numHowMuch;
        private Button Add;
        private TextBox txtGoal;
        private Label wefwefwef;
    }
}