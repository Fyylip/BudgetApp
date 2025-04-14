namespace LoginSystem
{
    partial class Rejestr
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
            label3 = new Label();
            checkBox1 = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            button2 = new Button();
            btnLogin = new Button();
            label4 = new Label();
            txtPassword2 = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 30F);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(300, 65);
            label3.Name = "label3";
            label3.Size = new Size(167, 54);
            label3.TabIndex = 15;
            label3.Text = "Register";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.None;
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14F);
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(465, 330);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(161, 29);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Show Passowrd";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(181, 211);
            label2.Name = "label2";
            label2.Size = new Size(103, 30);
            label2.TabIndex = 13;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(220, 149);
            label1.Name = "label1";
            label1.Size = new Size(64, 30);
            label1.TabIndex = 12;
            label1.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            txtPassword.ForeColor = SystemColors.ActiveCaptionText;
            txtPassword.Location = new Point(319, 212);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(167, 33);
            txtPassword.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtEmail.ForeColor = SystemColors.ActiveCaptionText;
            txtEmail.Location = new Point(319, 150);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(168, 33);
            txtEmail.TabIndex = 10;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.AliceBlue;
            button2.Location = new Point(391, 333);
            button2.Name = "button2";
            button2.Size = new Size(53, 27);
            button2.TabIndex = 9;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.AliceBlue;
            btnLogin.Location = new Point(327, 333);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(58, 27);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(182, 266);
            label4.Name = "label4";
            label4.Size = new Size(103, 30);
            label4.TabIndex = 17;
            label4.Text = "Password";
            // 
            // txtPassword2
            // 
            txtPassword2.Anchor = AnchorStyles.None;
            txtPassword2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            txtPassword2.ForeColor = SystemColors.ActiveCaptionText;
            txtPassword2.Location = new Point(320, 267);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.PasswordChar = '*';
            txtPassword2.Size = new Size(167, 33);
            txtPassword2.TabIndex = 16;
            // 
            // Rejestr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 11, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(txtPassword2);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(button2);
            Controls.Add(btnLogin);
            Name = "Rejestr";
            Text = "Rejestr";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private CheckBox checkBox1;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Button button2;
        private Button btnLogin;
        private Label label4;
        private TextBox txtPassword2;
    }
}