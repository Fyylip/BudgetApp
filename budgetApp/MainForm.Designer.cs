
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
            PieChartPanel = new Panel();
            LeftPanel = new TableLayoutPanel();
            LineChartPanel = new Panel();
            BarChartPanel = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            LeftPanel.SuspendLayout();
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
            panel1.Controls.Add(lblUserName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 100);
            panel1.TabIndex = 0;
            // 
            // PieChartPanel
            // 
            PieChartPanel.BackColor = Color.FromArgb(35, 23, 74);
            PieChartPanel.Dock = DockStyle.Fill;
            PieChartPanel.Location = new Point(3, 3);
            PieChartPanel.Name = "PieChartPanel";
            PieChartPanel.Size = new Size(238, 104);
            PieChartPanel.TabIndex = 0;
            // 
            // LeftPanel
            // 
            LeftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LeftPanel.BackColor = Color.Navy;
            LeftPanel.ColumnCount = 2;
            LeftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.272728F));
            LeftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.72727F));
            LeftPanel.Controls.Add(panel4, 1, 1);
            LeftPanel.Controls.Add(panel2, 0, 1);
            LeftPanel.Controls.Add(LineChartPanel, 1, 2);
            LeftPanel.Controls.Add(PieChartPanel, 0, 0);
            LeftPanel.Controls.Add(BarChartPanel, 1, 0);
            LeftPanel.Controls.Add(panel3, 0, 2);
            LeftPanel.Location = new Point(10, 105);
            LeftPanel.MaximumSize = new Size(2000, 1000);
            LeftPanel.MinimumSize = new Size(200, 323);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.RowCount = 3;
            LeftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            LeftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            LeftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            LeftPanel.Size = new Size(896, 332);
            LeftPanel.TabIndex = 1;
            // 
            // LineChartPanel
            // 
            LineChartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LineChartPanel.BackColor = Color.FromArgb(35, 23, 74);
            LineChartPanel.Location = new Point(247, 223);
            LineChartPanel.Name = "LineChartPanel";
            LineChartPanel.Size = new Size(646, 106);
            LineChartPanel.TabIndex = 4;
            // 
            // BarChartPanel
            // 
            BarChartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BarChartPanel.BackColor = Color.FromArgb(35, 23, 74);
            BarChartPanel.Location = new Point(247, 3);
            BarChartPanel.Name = "BarChartPanel";
            BarChartPanel.Size = new Size(646, 104);
            BarChartPanel.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(35, 23, 74);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 223);
            panel3.Name = "panel3";
            panel3.Size = new Size(238, 106);
            panel3.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(35, 23, 74);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 110);
            panel2.Margin = new Padding(3, 0, 3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(238, 110);
            panel2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(35, 23, 74);
            panel4.Location = new Point(247, 110);
            panel4.Margin = new Padding(3, 0, 3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(646, 107);
            panel4.TabIndex = 7;
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
            ResumeLayout(false);
        }

        #endregion
        private EventHandler test_Click;
        private Label lblUserName;
        private Panel panel1;
        private Panel PieChartPanel;
        private TableLayoutPanel LeftPanel;
        private Panel BarChartPanel;
        private Panel LineChartPanel;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
    }
}
