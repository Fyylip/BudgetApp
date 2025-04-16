namespace LoginSystem
{
    partial class LoginForm
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
            btnLogin = new Button();
            button2 = new Button();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.AliceBlue;
            btnLogin.Location = new Point(375, 252);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(58, 27);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.AliceBlue;
            button2.Location = new Point(439, 252);
            button2.Name = "button2";
            button2.Size = new Size(53, 27);
            button2.TabIndex = 1;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            //button2.Click += button2_Click;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.None;
            txtUserName.BackColor = Color.FromArgb(24, 15, 47);
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtUserName.ForeColor = SystemColors.ActiveCaptionText;
            txtUserName.Location = new Point(374, 147);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Login";
            txtUserName.Size = new Size(168, 26);
            txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = Color.FromArgb(24, 15, 47);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            txtPassword.ForeColor = SystemColors.ActiveCaptionText;
            txtPassword.Location = new Point(375, 195);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(167, 26);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(238, 146);
            label1.Name = "label1";
            label1.Size = new Size(121, 30);
            label1.TabIndex = 4;
            label1.Text = "User Name";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(238, 198);
            label2.Name = "label2";
            label2.Size = new Size(103, 30);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.None;
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14F);
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(498, 250);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(161, 29);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Show Passowrd";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 30F);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(346, 9);
            label3.Name = "label3";
            label3.Size = new Size(215, 54);
            label3.TabIndex = 7;
            label3.Text = "Zaloguj się";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            button1.FlatAppearance.MouseOverBackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.AliceBlue;
            button1.Location = new Point(407, 310);
            button1.Name = "button1";
            button1.Size = new Size(154, 27);
            button1.TabIndex = 8;
            button1.Text = "Create accond";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 15, 47);
            ClientSize = new Size(799, 465);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(button2);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button button2;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
        private Button button1;
    }
}
