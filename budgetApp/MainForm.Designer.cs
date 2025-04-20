
namespace budgetApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUserName = new Label();
            panel1 = new Panel();
            AddMoney = new Button();
            Total = new Label();
            LeftPanel = new TableLayoutPanel();
            BarChartPanel = new Panel();
            panel4 = new Panel();
            label6 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            label9 = new Label();
            label12 = new Label();
            label10 = new Label();
            label11 = new Label();
            panel6 = new Panel();
            label8 = new Label();
            LineChartPanel = new Panel();
            panel5 = new Panel();
            label7 = new Label();
            PieChartPanel = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            LeftPanel.SuspendLayout();
            BarChartPanel.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            LineChartPanel.SuspendLayout();
            panel5.SuspendLayout();
            PieChartPanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblUserName.ForeColor = Color.FromArgb(100, 10, 255);
            lblUserName.Location = new Point(40, 34);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(97, 33);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 23, 74);
            panel1.Controls.Add(AddMoney);
            panel1.Controls.Add(Total);
            panel1.Controls.Add(lblUserName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 100);
            panel1.TabIndex = 0;
            // 
            // AddMoney
            // 
            AddMoney.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            AddMoney.FlatAppearance.BorderSize = 0;
            AddMoney.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            AddMoney.FlatAppearance.MouseOverBackColor = Color.Black;
            AddMoney.FlatStyle = FlatStyle.Flat;
            AddMoney.ForeColor = Color.AliceBlue;
            AddMoney.Location = new Point(758, 34);
            AddMoney.Name = "AddMoney";
            AddMoney.Size = new Size(92, 27);
            AddMoney.TabIndex = 2;
            AddMoney.Text = "Add money";
            AddMoney.UseVisualStyleBackColor = true;
            AddMoney.Click += AddMoney_Click;
            // 
            // Total
            // 
            Total.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Total.AutoSize = true;
            Total.Font = new Font("Segoe UI", 16F);
            Total.ForeColor = Color.FromArgb(100, 10, 255);
            Total.Location = new Point(607, 34);
            Total.Name = "Total";
            Total.Size = new Size(83, 30);
            Total.TabIndex = 1;
            Total.Text = "label13";
            // 
            // LeftPanel
            // 
            LeftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LeftPanel.BackColor = Color.FromArgb(24, 15, 47);
            LeftPanel.ColumnCount = 2;
            LeftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.27273F));
            LeftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.72727F));
            LeftPanel.Controls.Add(BarChartPanel, 1, 0);
            LeftPanel.Controls.Add(panel3, 0, 1);
            LeftPanel.Controls.Add(LineChartPanel, 1, 1);
            LeftPanel.Controls.Add(PieChartPanel, 0, 0);
            LeftPanel.Location = new Point(10, 105);
            LeftPanel.MaximumSize = new Size(2000, 1000);
            LeftPanel.MinimumSize = new Size(200, 323);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.RowCount = 2;
            LeftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            LeftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            LeftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            LeftPanel.Size = new Size(896, 332);
            LeftPanel.TabIndex = 1;
            // 
            // BarChartPanel
            // 
            BarChartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BarChartPanel.BackColor = Color.FromArgb(35, 23, 74);
            BarChartPanel.Controls.Add(panel4);
            BarChartPanel.Location = new Point(247, 3);
            BarChartPanel.Name = "BarChartPanel";
            BarChartPanel.Size = new Size(646, 160);
            BarChartPanel.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(35, 23, 74);
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(646, 64);
            panel4.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI", 30F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(640, 54);
            label6.TabIndex = 0;
            label6.Text = "Saving goals";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(35, 23, 74);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 169);
            panel3.Name = "panel3";
            panel3.Size = new Size(238, 160);
            panel3.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(35, 23, 74);
            panel7.Controls.Add(label9);
            panel7.Controls.Add(label12);
            panel7.Controls.Add(label10);
            panel7.Controls.Add(label11);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 38);
            panel7.Name = "panel7";
            panel7.Size = new Size(238, 122);
            panel7.TabIndex = 5;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(55, 17);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 1;
            label9.Text = "add expense";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left;
            label12.AutoSize = true;
            label12.ForeColor = Color.White;
            label12.Location = new Point(11, 101);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 4;
            label12.Text = "label12";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(11, 51);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 2;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left;
            label11.AutoSize = true;
            label11.ForeColor = Color.White;
            label11.Location = new Point(11, 75);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 3;
            label11.Text = "label11";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(35, 23, 74);
            panel6.Controls.Add(label8);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(238, 38);
            panel6.TabIndex = 0;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.BackColor = Color.FromArgb(35, 23, 74);
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(235, 23);
            label8.TabIndex = 0;
            label8.Text = "Money spent on addictions";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LineChartPanel
            // 
            LineChartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LineChartPanel.BackColor = Color.FromArgb(35, 23, 74);
            LineChartPanel.Controls.Add(panel5);
            LineChartPanel.Location = new Point(247, 169);
            LineChartPanel.Name = "LineChartPanel";
            LineChartPanel.Size = new Size(646, 160);
            LineChartPanel.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(label7);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(646, 54);
            panel5.TabIndex = 0;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.Font = new Font("Segoe UI", 30F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(646, 54);
            label7.TabIndex = 1;
            label7.Text = "Expenses during the year";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // PieChartPanel
            // 
            PieChartPanel.BackColor = Color.FromArgb(35, 23, 74);
            PieChartPanel.Controls.Add(panel2);
            PieChartPanel.Dock = DockStyle.Fill;
            PieChartPanel.Location = new Point(3, 3);
            PieChartPanel.Name = "PieChartPanel";
            PieChartPanel.Size = new Size(238, 160);
            PieChartPanel.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 120);
            panel2.Name = "panel2";
            panel2.Size = new Size(238, 40);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(187, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(143, 15);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(99, 15);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(55, 15);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(11, 15);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 4;
            label5.Text = "label5";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(916, 450);
            Controls.Add(LeftPanel);
            Controls.Add(panel1);
            Name = "MainForm";
            Padding = new Padding(10, 5, 10, 10);
            Text = "Form1";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            LeftPanel.ResumeLayout(false);
            BarChartPanel.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            LineChartPanel.ResumeLayout(false);
            panel5.ResumeLayout(false);
            PieChartPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private EventHandler test_Click;
        private Label lblUserName;
        private Panel panel1;
        private TableLayoutPanel LeftPanel;
        private Panel BarChartPanel;
        private Panel LineChartPanel;
        private Panel panel3;
        private Panel PieChartPanel;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private Panel panel4;
        private Label label6;
        private Panel panel5;
        private Label label7;
        private Panel panel6;
        private Label label8;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Panel panel7;
        private Label Total;
        private Button AddMoney;
    }
}
