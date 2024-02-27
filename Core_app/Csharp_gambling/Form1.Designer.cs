namespace csharp_gambling
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
            btnLoginLogin = new Button();
            btnLoginSignup = new Button();
            textBoxLoginPassword = new TextBox();
            lblLoginPassword = new Label();
            textBoxLoginUsername = new TextBox();
            lblLoginUsername = new Label();
            lblLoginHeader = new Label();
            lblLoginTitle = new Label();
            panelSignup = new Panel();
            btnSignupCreateAccount = new Button();
            btnSignupLogin = new Button();
            textBoxSignupPassword = new TextBox();
            lblSignupPassword = new Label();
            textBoxSignupUsername = new TextBox();
            lblSignupUsername = new Label();
            lblSignupHeader = new Label();
            lblSignupTitle = new Label();
            textBoxSignupConfirmPassword = new TextBox();
            lblSignupConfirmPassword = new Label();
            panelLogin.SuspendLayout();
            panelSignup.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = SystemColors.ActiveBorder;
            panelLogin.Controls.Add(btnLoginLogin);
            panelLogin.Controls.Add(btnLoginSignup);
            panelLogin.Controls.Add(textBoxLoginPassword);
            panelLogin.Controls.Add(lblLoginPassword);
            panelLogin.Controls.Add(textBoxLoginUsername);
            panelLogin.Controls.Add(lblLoginUsername);
            panelLogin.Controls.Add(lblLoginHeader);
            panelLogin.Controls.Add(lblLoginTitle);
            panelLogin.Location = new Point(0, -1);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(361, 654);
            panelLogin.TabIndex = 0;
            // 
            // btnLoginLogin
            // 
            btnLoginLogin.BackColor = Color.LimeGreen;
            btnLoginLogin.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoginLogin.Location = new Point(37, 557);
            btnLoginLogin.Name = "btnLoginLogin";
            btnLoginLogin.Size = new Size(261, 57);
            btnLoginLogin.TabIndex = 7;
            btnLoginLogin.Text = "Log-in";
            btnLoginLogin.UseVisualStyleBackColor = false;
            // 
            // btnLoginSignup
            // 
            btnLoginSignup.Location = new Point(37, 326);
            btnLoginSignup.Name = "btnLoginSignup";
            btnLoginSignup.Size = new Size(261, 23);
            btnLoginSignup.TabIndex = 6;
            btnLoginSignup.Text = "Opret konto?";
            btnLoginSignup.UseVisualStyleBackColor = true;
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLoginPassword.Location = new Point(37, 286);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PlaceholderText = "Skriv adgangskode";
            textBoxLoginPassword.Size = new Size(261, 34);
            textBoxLoginPassword.TabIndex = 5;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginPassword.Location = new Point(37, 255);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(138, 28);
            lblLoginPassword.TabIndex = 4;
            lblLoginPassword.Text = "Adgangskode:";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLoginUsername.Location = new Point(37, 215);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.PlaceholderText = "Skriv brugernavn";
            textBoxLoginUsername.Size = new Size(261, 34);
            textBoxLoginUsername.TabIndex = 3;
            // 
            // lblLoginUsername
            // 
            lblLoginUsername.AutoSize = true;
            lblLoginUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginUsername.Location = new Point(37, 184);
            lblLoginUsername.Name = "lblLoginUsername";
            lblLoginUsername.Size = new Size(116, 28);
            lblLoginUsername.TabIndex = 2;
            lblLoginUsername.Text = "Brugernavn:";
            // 
            // lblLoginHeader
            // 
            lblLoginHeader.AutoSize = true;
            lblLoginHeader.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginHeader.Location = new Point(110, 102);
            lblLoginHeader.Name = "lblLoginHeader";
            lblLoginHeader.RightToLeft = RightToLeft.No;
            lblLoginHeader.Size = new Size(95, 37);
            lblLoginHeader.TabIndex = 1;
            lblLoginHeader.Text = "Log-in";
            lblLoginHeader.UseMnemonic = false;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 30F, FontStyle.Underline, GraphicsUnit.Point);
            lblLoginTitle.Location = new Point(56, 21);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.RightToLeft = RightToLeft.No;
            lblLoginTitle.Size = new Size(227, 54);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Jytte casino";
            // 
            // panelSignup
            // 
            panelSignup.BackColor = SystemColors.ActiveBorder;
            panelSignup.Controls.Add(textBoxSignupConfirmPassword);
            panelSignup.Controls.Add(lblSignupConfirmPassword);
            panelSignup.Controls.Add(btnSignupCreateAccount);
            panelSignup.Controls.Add(btnSignupLogin);
            panelSignup.Controls.Add(textBoxSignupPassword);
            panelSignup.Controls.Add(lblSignupPassword);
            panelSignup.Controls.Add(textBoxSignupUsername);
            panelSignup.Controls.Add(lblSignupUsername);
            panelSignup.Controls.Add(lblSignupHeader);
            panelSignup.Controls.Add(lblSignupTitle);
            panelSignup.Location = new Point(378, -1);
            panelSignup.Name = "panelSignup";
            panelSignup.Size = new Size(361, 654);
            panelSignup.TabIndex = 8;
            // 
            // btnSignupCreateAccount
            // 
            btnSignupCreateAccount.BackColor = Color.LimeGreen;
            btnSignupCreateAccount.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnSignupCreateAccount.Location = new Point(37, 557);
            btnSignupCreateAccount.Name = "btnSignupCreateAccount";
            btnSignupCreateAccount.Size = new Size(261, 57);
            btnSignupCreateAccount.TabIndex = 7;
            btnSignupCreateAccount.Text = "Opret og log-in";
            btnSignupCreateAccount.UseVisualStyleBackColor = false;
            // 
            // btnSignupLogin
            // 
            btnSignupLogin.Location = new Point(37, 395);
            btnSignupLogin.Name = "btnSignupLogin";
            btnSignupLogin.Size = new Size(261, 23);
            btnSignupLogin.TabIndex = 6;
            btnSignupLogin.Text = "Log-in?";
            btnSignupLogin.UseVisualStyleBackColor = true;
            // 
            // textBoxSignupPassword
            // 
            textBoxSignupPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSignupPassword.Location = new Point(37, 286);
            textBoxSignupPassword.Name = "textBoxSignupPassword";
            textBoxSignupPassword.PlaceholderText = "Skriv adgangskode";
            textBoxSignupPassword.Size = new Size(261, 34);
            textBoxSignupPassword.TabIndex = 5;
            // 
            // lblSignupPassword
            // 
            lblSignupPassword.AutoSize = true;
            lblSignupPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupPassword.Location = new Point(37, 255);
            lblSignupPassword.Name = "lblSignupPassword";
            lblSignupPassword.Size = new Size(138, 28);
            lblSignupPassword.TabIndex = 4;
            lblSignupPassword.Text = "Adgangskode:";
            // 
            // textBoxSignupUsername
            // 
            textBoxSignupUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSignupUsername.Location = new Point(37, 215);
            textBoxSignupUsername.Name = "textBoxSignupUsername";
            textBoxSignupUsername.PlaceholderText = "Skriv brugernavn";
            textBoxSignupUsername.Size = new Size(261, 34);
            textBoxSignupUsername.TabIndex = 3;
            // 
            // lblSignupUsername
            // 
            lblSignupUsername.AutoSize = true;
            lblSignupUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupUsername.Location = new Point(37, 184);
            lblSignupUsername.Name = "lblSignupUsername";
            lblSignupUsername.Size = new Size(116, 28);
            lblSignupUsername.TabIndex = 2;
            lblSignupUsername.Text = "Brugernavn:";
            // 
            // lblSignupHeader
            // 
            lblSignupHeader.AutoSize = true;
            lblSignupHeader.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupHeader.Location = new Point(110, 102);
            lblSignupHeader.Name = "lblSignupHeader";
            lblSignupHeader.RightToLeft = RightToLeft.No;
            lblSignupHeader.Size = new Size(111, 37);
            lblSignupHeader.TabIndex = 1;
            lblSignupHeader.Text = "Sign-up";
            lblSignupHeader.UseMnemonic = false;
            // 
            // lblSignupTitle
            // 
            lblSignupTitle.AutoSize = true;
            lblSignupTitle.Font = new Font("Segoe UI", 30F, FontStyle.Underline, GraphicsUnit.Point);
            lblSignupTitle.Location = new Point(56, 21);
            lblSignupTitle.Name = "lblSignupTitle";
            lblSignupTitle.RightToLeft = RightToLeft.No;
            lblSignupTitle.Size = new Size(227, 54);
            lblSignupTitle.TabIndex = 0;
            lblSignupTitle.Text = "Jytte casino";
            // 
            // textBoxSignupConfirmPassword
            // 
            textBoxSignupConfirmPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSignupConfirmPassword.Location = new Point(37, 355);
            textBoxSignupConfirmPassword.Name = "textBoxSignupConfirmPassword";
            textBoxSignupConfirmPassword.PlaceholderText = "Skriv adgangskode igen";
            textBoxSignupConfirmPassword.Size = new Size(261, 34);
            textBoxSignupConfirmPassword.TabIndex = 9;
            // 
            // lblSignupConfirmPassword
            // 
            lblSignupConfirmPassword.AutoSize = true;
            lblSignupConfirmPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupConfirmPassword.Location = new Point(37, 324);
            lblSignupConfirmPassword.Name = "lblSignupConfirmPassword";
            lblSignupConfirmPassword.Size = new Size(204, 28);
            lblSignupConfirmPassword.TabIndex = 8;
            lblSignupConfirmPassword.Text = "Gentag adgangskode:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 653);
            Controls.Add(panelSignup);
            Controls.Add(panelLogin);
            Name = "Form1";
            Text = "Form1";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelSignup.ResumeLayout(false);
            panelSignup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private TextBox textBoxLoginUsername;
        private Label lblLoginUsername;
        private Label lblLoginHeader;
        private Label lblLoginTitle;
        private TextBox textBoxLoginPassword;
        private Label lblLoginPassword;
        private Button btnLoginLogin;
        private Button btnLoginSignup;
        private Panel panelSignup;
        private Button btnSignupCreateAccount;
        private Button btnSignupLogin;
        private TextBox textBoxSignupPassword;
        private Label lblSignupPassword;
        private TextBox textBoxSignupUsername;
        private Label lblSignupUsername;
        private Label lblSignupHeader;
        private Label lblSignupTitle;
        private TextBox textBoxSignupConfirmPassword;
        private Label lblSignupConfirmPassword;
    }
}