namespace budgetApp
{
    partial class EditAddictions
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
            txtNameAddition = new TextBox();
            AdditionSpend = new TextBox();
            label2 = new Label();
            EdidAddition = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(128, 37);
            label1.Name = "label1";
            label1.Size = new Size(115, 21);
            label1.TabIndex = 0;
            label1.Text = "Name Addition";
            // 
            // txtNameAddition
            // 
            txtNameAddition.Location = new Point(249, 39);
            txtNameAddition.Name = "txtNameAddition";
            txtNameAddition.Size = new Size(100, 23);
            txtNameAddition.TabIndex = 1;
            // 
            // AdditionSpend
            // 
            AdditionSpend.Location = new Point(249, 89);
            AdditionSpend.Name = "AdditionSpend";
            AdditionSpend.Size = new Size(100, 23);
            AdditionSpend.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(58, 89);
            label2.Name = "label2";
            label2.Size = new Size(185, 21);
            label2.TabIndex = 3;
            label2.Text = "how much did you spend";
            // 
            // EdidAddition
            // 
            EdidAddition.Location = new Point(249, 141);
            EdidAddition.Name = "EdidAddition";
            EdidAddition.Size = new Size(75, 23);
            EdidAddition.TabIndex = 4;
            EdidAddition.Text = "Edit";
            EdidAddition.UseVisualStyleBackColor = true;
            EdidAddition.Click += EdidAddition_Click;
            // 
            // EditAddictions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(387, 202);
            Controls.Add(EdidAddition);
            Controls.Add(label2);
            Controls.Add(AdditionSpend);
            Controls.Add(txtNameAddition);
            Controls.Add(label1);
            Name = "EditAddictions";
            Text = "EditAddictions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNameAddition;
        private TextBox AdditionSpend;
        private Label label2;
        private Button EdidAddition;
    }
}