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
            AmountInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Add = new Button();
            radioFood = new RadioButton();
            groupBox1 = new GroupBox();
            radioPleasures = new RadioButton();
            radioMustHave = new RadioButton();
            buttonEdit = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // AmountInput
            // 
            AmountInput.Location = new Point(205, 59);
            AmountInput.Name = "AmountInput";
            AmountInput.Size = new Size(100, 23);
            AmountInput.TabIndex = 0;
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
            // Add
            // 
            Add.Location = new Point(116, 159);
            Add.Name = "Add";
            Add.Size = new Size(75, 23);
            Add.TabIndex = 4;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += button1_Click;
            // 
            // radioFood
            // 
            radioFood.AutoSize = true;
            radioFood.ForeColor = Color.White;
            radioFood.Location = new Point(6, 15);
            radioFood.Name = "radioFood";
            radioFood.Size = new Size(52, 19);
            radioFood.TabIndex = 5;
            radioFood.TabStop = true;
            radioFood.Text = "Food";
            radioFood.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioPleasures);
            groupBox1.Controls.Add(radioMustHave);
            groupBox1.Controls.Add(radioFood);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(205, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(136, 94);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select options";
            // 
            // radioPleasures
            // 
            radioPleasures.AutoSize = true;
            radioPleasures.ForeColor = Color.White;
            radioPleasures.Location = new Point(4, 65);
            radioPleasures.Name = "radioPleasures";
            radioPleasures.Size = new Size(74, 19);
            radioPleasures.TabIndex = 7;
            radioPleasures.TabStop = true;
            radioPleasures.Text = "Pleasures";
            radioPleasures.UseVisualStyleBackColor = true;
            // 
            // radioMustHave
            // 
            radioMustHave.AutoSize = true;
            radioMustHave.ForeColor = Color.White;
            radioMustHave.Location = new Point(4, 40);
            radioMustHave.Name = "radioMustHave";
            radioMustHave.Size = new Size(80, 19);
            radioMustHave.TabIndex = 6;
            radioMustHave.TabStop = true;
            radioMustHave.Text = "Must have";
            radioMustHave.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(35, 159);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // AddPieChart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(365, 213);
            Controls.Add(buttonEdit);
            Controls.Add(groupBox1);
            Controls.Add(Add);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AmountInput);
            Name = "AddPieChart";
            Text = "AddMoney";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox AmountInput;
        private Label label1;
        private Label label2;
        private Button Add;
        private RadioButton radioFood;
        private GroupBox groupBox1;
        private RadioButton radioPleasures;
        private RadioButton radioMustHave;
        private Button buttonEdit;
    }
}