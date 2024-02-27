namespace Csharp_gambling_app
{
    partial class Form1
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
            panelLogin = new Panel();
            lblLoginHeader = new Label();
            lblLoginTitle = new Label();
            textBoxLoginUsername = new TextBox();
            lblLoginUsername = new Label();
            lblLoginPassword = new Label();
            textBoxLoginPassword = new TextBox();
            button1 = new Button();
            btnLoginCreateAccount = new Button();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = SystemColors.ActiveBorder;
            panelLogin.Controls.Add(btnLoginCreateAccount);
            panelLogin.Controls.Add(button1);
            panelLogin.Controls.Add(lblLoginPassword);
            panelLogin.Controls.Add(textBoxLoginPassword);
            panelLogin.Controls.Add(lblLoginUsername);
            panelLogin.Controls.Add(textBoxLoginUsername);
            panelLogin.Controls.Add(lblLoginTitle);
            panelLogin.Controls.Add(lblLoginHeader);
            panelLogin.Location = new Point(1, 3);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(330, 657);
            panelLogin.TabIndex = 0;
            // 
            // lblLoginHeader
            // 
            lblLoginHeader.AutoSize = true;
            lblLoginHeader.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoginHeader.Location = new Point(120, 80);
            lblLoginHeader.Name = "lblLoginHeader";
            lblLoginHeader.Size = new Size(64, 28);
            lblLoginHeader.TabIndex = 0;
            lblLoginHeader.Text = "Login";
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 30F, FontStyle.Underline, GraphicsUnit.Point);
            lblLoginTitle.Location = new Point(43, 6);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(227, 54);
            lblLoginTitle.TabIndex = 1;
            lblLoginTitle.Text = "Jytte casino";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLoginUsername.Location = new Point(29, 172);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.PlaceholderText = "Skriv brugernavn";
            textBoxLoginUsername.Size = new Size(269, 34);
            textBoxLoginUsername.TabIndex = 2;
            // 
            // lblLoginUsername
            // 
            lblLoginUsername.AutoSize = true;
            lblLoginUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginUsername.Location = new Point(29, 141);
            lblLoginUsername.Name = "lblLoginUsername";
            lblLoginUsername.Size = new Size(116, 28);
            lblLoginUsername.TabIndex = 3;
            lblLoginUsername.Text = "Brugernavn:";
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginPassword.Location = new Point(29, 210);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(138, 28);
            lblLoginPassword.TabIndex = 5;
            lblLoginPassword.Text = "Adgangskode:";
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLoginPassword.Location = new Point(29, 241);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PlaceholderText = "Skriv adgangskode";
            textBoxLoginPassword.Size = new Size(269, 34);
            textBoxLoginPassword.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(29, 564);
            button1.Name = "button1";
            button1.Size = new Size(269, 48);
            button1.TabIndex = 6;
            button1.Text = "Log-in";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnLoginCreateAccount
            // 
            btnLoginCreateAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoginCreateAccount.Location = new Point(29, 281);
            btnLoginCreateAccount.Name = "btnLoginCreateAccount";
            btnLoginCreateAccount.Size = new Size(269, 23);
            btnLoginCreateAccount.TabIndex = 7;
            btnLoginCreateAccount.Text = "Opret konto";
            btnLoginCreateAccount.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 657);
            Controls.Add(panelLogin);
            Name = "Form1";
            Text = "Form1";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Label lblLoginHeader;
        private Label lblLoginTitle;
        private Label lblLoginPassword;
        private TextBox textBoxLoginPassword;
        private Label lblLoginUsername;
        private TextBox textBoxLoginUsername;
        private Button button1;
        private Button btnLoginCreateAccount;
    }
}