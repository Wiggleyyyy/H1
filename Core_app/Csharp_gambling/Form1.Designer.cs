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
            textBoxSignupConfirmPassword = new TextBox();
            lblSignupConfirmPassword = new Label();
            btnSignupCreateAccount = new Button();
            btnSignupLogin = new Button();
            textBoxSignupPassword = new TextBox();
            lblSignupPassword = new Label();
            textBoxSignupUsername = new TextBox();
            lblSignupUsername = new Label();
            lblSignupHeader = new Label();
            lblSignupTitle = new Label();
            panelHomePage = new Panel();
            panelHomeNavbar = new Panel();
            btnHomeNavbarRoulette = new Button();
            btnHomeNavbarCrash = new Button();
            btnHomeNavbarBlackjack = new Button();
            btnHomeNavbarMines = new Button();
            lblHomeNavbarCurrency = new Label();
            lblHomeNavbarUsername = new Label();
            btnHomeNavbarSignOut = new Button();
            lblHomeNavbarTitle = new Label();
            panelLogin.SuspendLayout();
            panelSignup.SuspendLayout();
            panelHomePage.SuspendLayout();
            panelHomeNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(51, 50, 51);
            panelLogin.Controls.Add(btnLoginLogin);
            panelLogin.Controls.Add(btnLoginSignup);
            panelLogin.Controls.Add(textBoxLoginPassword);
            panelLogin.Controls.Add(lblLoginPassword);
            panelLogin.Controls.Add(textBoxLoginUsername);
            panelLogin.Controls.Add(lblLoginUsername);
            panelLogin.Controls.Add(lblLoginHeader);
            panelLogin.Controls.Add(lblLoginTitle);
            panelLogin.ForeColor = SystemColors.Control;
            panelLogin.Location = new Point(0, -1);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(361, 654);
            panelLogin.TabIndex = 0;
            // 
            // btnLoginLogin
            // 
            btnLoginLogin.BackColor = Color.FromArgb(175, 141, 252);
            btnLoginLogin.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            btnLoginLogin.FlatAppearance.BorderSize = 0;
            btnLoginLogin.FlatStyle = FlatStyle.Flat;
            btnLoginLogin.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoginLogin.ForeColor = Color.White;
            btnLoginLogin.Location = new Point(37, 557);
            btnLoginLogin.Name = "btnLoginLogin";
            btnLoginLogin.Size = new Size(261, 57);
            btnLoginLogin.TabIndex = 4;
            btnLoginLogin.Text = "Log-in";
            btnLoginLogin.UseVisualStyleBackColor = false;
            btnLoginLogin.Click += btnLoginLogin_Click;
            // 
            // btnLoginSignup
            // 
            btnLoginSignup.BackColor = Color.Transparent;
            btnLoginSignup.FlatAppearance.BorderSize = 0;
            btnLoginSignup.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLoginSignup.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLoginSignup.FlatStyle = FlatStyle.Flat;
            btnLoginSignup.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Underline, GraphicsUnit.Point);
            btnLoginSignup.ForeColor = Color.White;
            btnLoginSignup.Location = new Point(37, 528);
            btnLoginSignup.Name = "btnLoginSignup";
            btnLoginSignup.Size = new Size(261, 23);
            btnLoginSignup.TabIndex = 3;
            btnLoginSignup.Text = "Har du ikke en konto? Opret en";
            btnLoginSignup.UseVisualStyleBackColor = false;
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.BorderStyle = BorderStyle.None;
            textBoxLoginPassword.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLoginPassword.Location = new Point(37, 285);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PlaceholderText = "Skriv adgangskode";
            textBoxLoginPassword.Size = new Size(261, 23);
            textBoxLoginPassword.TabIndex = 2;
            textBoxLoginPassword.UseSystemPasswordChar = true;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginPassword.Location = new Point(31, 256);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(140, 25);
            lblLoginPassword.TabIndex = 4;
            lblLoginPassword.Text = "Adgangskode:";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.BorderStyle = BorderStyle.None;
            textBoxLoginUsername.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLoginUsername.Location = new Point(37, 215);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.PlaceholderText = "Skriv brugernavn";
            textBoxLoginUsername.Size = new Size(261, 23);
            textBoxLoginUsername.TabIndex = 1;
            // 
            // lblLoginUsername
            // 
            lblLoginUsername.AutoSize = true;
            lblLoginUsername.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginUsername.Location = new Point(31, 186);
            lblLoginUsername.Name = "lblLoginUsername";
            lblLoginUsername.Size = new Size(119, 25);
            lblLoginUsername.TabIndex = 2;
            lblLoginUsername.Text = "Brugernavn:";
            // 
            // lblLoginHeader
            // 
            lblLoginHeader.AutoSize = true;
            lblLoginHeader.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginHeader.Location = new Point(122, 71);
            lblLoginHeader.Name = "lblLoginHeader";
            lblLoginHeader.RightToLeft = RightToLeft.No;
            lblLoginHeader.Size = new Size(89, 31);
            lblLoginHeader.TabIndex = 1;
            lblLoginHeader.Text = "Log-in";
            lblLoginHeader.UseMnemonic = false;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Underline, GraphicsUnit.Point);
            lblLoginTitle.ForeColor = Color.White;
            lblLoginTitle.Location = new Point(25, 21);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.RightToLeft = RightToLeft.No;
            lblLoginTitle.Size = new Size(305, 46);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "JYTTE CASINO";
            // 
            // panelSignup
            // 
            panelSignup.BackColor = Color.FromArgb(51, 50, 51);
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
            panelSignup.Location = new Point(0, -1);
            panelSignup.Name = "panelSignup";
            panelSignup.Size = new Size(361, 654);
            panelSignup.TabIndex = 8;
            panelSignup.Visible = false;
            // 
            // textBoxSignupConfirmPassword
            // 
            textBoxSignupConfirmPassword.BackColor = Color.White;
            textBoxSignupConfirmPassword.BorderStyle = BorderStyle.None;
            textBoxSignupConfirmPassword.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSignupConfirmPassword.ForeColor = Color.Black;
            textBoxSignupConfirmPassword.Location = new Point(37, 355);
            textBoxSignupConfirmPassword.Name = "textBoxSignupConfirmPassword";
            textBoxSignupConfirmPassword.PlaceholderText = "Gentag adgangskode";
            textBoxSignupConfirmPassword.Size = new Size(261, 23);
            textBoxSignupConfirmPassword.TabIndex = 7;
            textBoxSignupConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblSignupConfirmPassword
            // 
            lblSignupConfirmPassword.AutoSize = true;
            lblSignupConfirmPassword.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupConfirmPassword.ForeColor = Color.White;
            lblSignupConfirmPassword.Location = new Point(31, 326);
            lblSignupConfirmPassword.Name = "lblSignupConfirmPassword";
            lblSignupConfirmPassword.Size = new Size(206, 25);
            lblSignupConfirmPassword.TabIndex = 8;
            lblSignupConfirmPassword.Text = "Gentag adgangskode:";
            // 
            // btnSignupCreateAccount
            // 
            btnSignupCreateAccount.BackColor = Color.FromArgb(175, 141, 252);
            btnSignupCreateAccount.FlatAppearance.BorderSize = 0;
            btnSignupCreateAccount.FlatStyle = FlatStyle.Flat;
            btnSignupCreateAccount.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignupCreateAccount.ForeColor = Color.White;
            btnSignupCreateAccount.Location = new Point(37, 557);
            btnSignupCreateAccount.Name = "btnSignupCreateAccount";
            btnSignupCreateAccount.Size = new Size(261, 57);
            btnSignupCreateAccount.TabIndex = 9;
            btnSignupCreateAccount.Text = "Opret og log-in";
            btnSignupCreateAccount.UseVisualStyleBackColor = false;
            btnSignupCreateAccount.Click += btnSignupCreateAccount_Click;
            // 
            // btnSignupLogin
            // 
            btnSignupLogin.BackColor = Color.Transparent;
            btnSignupLogin.FlatAppearance.BorderSize = 0;
            btnSignupLogin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSignupLogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSignupLogin.FlatStyle = FlatStyle.Flat;
            btnSignupLogin.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Underline, GraphicsUnit.Point);
            btnSignupLogin.ForeColor = Color.White;
            btnSignupLogin.Location = new Point(37, 528);
            btnSignupLogin.Name = "btnSignupLogin";
            btnSignupLogin.Size = new Size(261, 23);
            btnSignupLogin.TabIndex = 8;
            btnSignupLogin.Text = "Log-in?";
            btnSignupLogin.UseVisualStyleBackColor = false;
            // 
            // textBoxSignupPassword
            // 
            textBoxSignupPassword.BackColor = Color.White;
            textBoxSignupPassword.BorderStyle = BorderStyle.None;
            textBoxSignupPassword.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSignupPassword.ForeColor = Color.Black;
            textBoxSignupPassword.Location = new Point(37, 285);
            textBoxSignupPassword.Name = "textBoxSignupPassword";
            textBoxSignupPassword.PlaceholderText = "Skriv adgangskode";
            textBoxSignupPassword.Size = new Size(261, 23);
            textBoxSignupPassword.TabIndex = 6;
            textBoxSignupPassword.UseSystemPasswordChar = true;
            // 
            // lblSignupPassword
            // 
            lblSignupPassword.AutoSize = true;
            lblSignupPassword.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupPassword.ForeColor = Color.White;
            lblSignupPassword.Location = new Point(31, 256);
            lblSignupPassword.Name = "lblSignupPassword";
            lblSignupPassword.Size = new Size(140, 25);
            lblSignupPassword.TabIndex = 4;
            lblSignupPassword.Text = "Adgangskode:";
            // 
            // textBoxSignupUsername
            // 
            textBoxSignupUsername.BackColor = Color.White;
            textBoxSignupUsername.BorderStyle = BorderStyle.None;
            textBoxSignupUsername.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSignupUsername.ForeColor = Color.Black;
            textBoxSignupUsername.Location = new Point(37, 215);
            textBoxSignupUsername.Name = "textBoxSignupUsername";
            textBoxSignupUsername.PlaceholderText = "Skriv brugernavn";
            textBoxSignupUsername.Size = new Size(261, 23);
            textBoxSignupUsername.TabIndex = 5;
            // 
            // lblSignupUsername
            // 
            lblSignupUsername.AutoSize = true;
            lblSignupUsername.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupUsername.ForeColor = Color.White;
            lblSignupUsername.Location = new Point(31, 186);
            lblSignupUsername.Name = "lblSignupUsername";
            lblSignupUsername.Size = new Size(119, 25);
            lblSignupUsername.TabIndex = 2;
            lblSignupUsername.Text = "Brugernavn:";
            // 
            // lblSignupHeader
            // 
            lblSignupHeader.AutoSize = true;
            lblSignupHeader.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignupHeader.ForeColor = Color.White;
            lblSignupHeader.Location = new Point(122, 71);
            lblSignupHeader.Name = "lblSignupHeader";
            lblSignupHeader.RightToLeft = RightToLeft.No;
            lblSignupHeader.Size = new Size(107, 31);
            lblSignupHeader.TabIndex = 1;
            lblSignupHeader.Text = "Sign-up";
            lblSignupHeader.UseMnemonic = false;
            // 
            // lblSignupTitle
            // 
            lblSignupTitle.AutoSize = true;
            lblSignupTitle.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Underline, GraphicsUnit.Point);
            lblSignupTitle.ForeColor = Color.White;
            lblSignupTitle.Location = new Point(25, 21);
            lblSignupTitle.Name = "lblSignupTitle";
            lblSignupTitle.RightToLeft = RightToLeft.No;
            lblSignupTitle.Size = new Size(305, 46);
            lblSignupTitle.TabIndex = 0;
            lblSignupTitle.Text = "JYTTE CASINO";
            // 
            // panelHomePage
            // 
            panelHomePage.Controls.Add(panelHomeNavbar);
            panelHomePage.Location = new Point(0, 0);
            panelHomePage.Name = "panelHomePage";
            panelHomePage.Size = new Size(1263, 653);
            panelHomePage.TabIndex = 9;
            panelHomePage.Visible = false;
            // 
            // panelHomeNavbar
            // 
            panelHomeNavbar.BackColor = SystemColors.ActiveBorder;
            panelHomeNavbar.Controls.Add(btnHomeNavbarRoulette);
            panelHomeNavbar.Controls.Add(btnHomeNavbarCrash);
            panelHomeNavbar.Controls.Add(btnHomeNavbarBlackjack);
            panelHomeNavbar.Controls.Add(btnHomeNavbarMines);
            panelHomeNavbar.Controls.Add(lblHomeNavbarCurrency);
            panelHomeNavbar.Controls.Add(lblHomeNavbarUsername);
            panelHomeNavbar.Controls.Add(btnHomeNavbarSignOut);
            panelHomeNavbar.Controls.Add(lblHomeNavbarTitle);
            panelHomeNavbar.Location = new Point(0, 0);
            panelHomeNavbar.Name = "panelHomeNavbar";
            panelHomeNavbar.Size = new Size(1275, 100);
            panelHomeNavbar.TabIndex = 0;
            // 
            // btnHomeNavbarRoulette
            // 
            btnHomeNavbarRoulette.Location = new Point(696, 57);
            btnHomeNavbarRoulette.Name = "btnHomeNavbarRoulette";
            btnHomeNavbarRoulette.Size = new Size(75, 23);
            btnHomeNavbarRoulette.TabIndex = 7;
            btnHomeNavbarRoulette.Text = "Roulette";
            btnHomeNavbarRoulette.UseVisualStyleBackColor = true;
            // 
            // btnHomeNavbarCrash
            // 
            btnHomeNavbarCrash.Location = new Point(606, 57);
            btnHomeNavbarCrash.Name = "btnHomeNavbarCrash";
            btnHomeNavbarCrash.Size = new Size(75, 23);
            btnHomeNavbarCrash.TabIndex = 6;
            btnHomeNavbarCrash.Text = "Crash";
            btnHomeNavbarCrash.UseVisualStyleBackColor = true;
            // 
            // btnHomeNavbarBlackjack
            // 
            btnHomeNavbarBlackjack.Location = new Point(524, 57);
            btnHomeNavbarBlackjack.Name = "btnHomeNavbarBlackjack";
            btnHomeNavbarBlackjack.Size = new Size(75, 23);
            btnHomeNavbarBlackjack.TabIndex = 5;
            btnHomeNavbarBlackjack.Text = "Blackjack";
            btnHomeNavbarBlackjack.UseVisualStyleBackColor = true;
            // 
            // btnHomeNavbarMines
            // 
            btnHomeNavbarMines.Location = new Point(443, 57);
            btnHomeNavbarMines.Name = "btnHomeNavbarMines";
            btnHomeNavbarMines.Size = new Size(75, 23);
            btnHomeNavbarMines.TabIndex = 4;
            btnHomeNavbarMines.Text = "Mines";
            btnHomeNavbarMines.UseVisualStyleBackColor = true;
            // 
            // lblHomeNavbarCurrency
            // 
            lblHomeNavbarCurrency.AutoSize = true;
            lblHomeNavbarCurrency.Location = new Point(29, 48);
            lblHomeNavbarCurrency.Name = "lblHomeNavbarCurrency";
            lblHomeNavbarCurrency.Size = new Size(89, 15);
            lblHomeNavbarCurrency.TabIndex = 3;
            lblHomeNavbarCurrency.Text = "$<CURRENCY>";
            // 
            // lblHomeNavbarUsername
            // 
            lblHomeNavbarUsername.AutoSize = true;
            lblHomeNavbarUsername.Location = new Point(25, 20);
            lblHomeNavbarUsername.Name = "lblHomeNavbarUsername";
            lblHomeNavbarUsername.Size = new Size(98, 15);
            lblHomeNavbarUsername.TabIndex = 2;
            lblHomeNavbarUsername.Text = "<BRUGERNAVN>";
            // 
            // btnHomeNavbarSignOut
            // 
            btnHomeNavbarSignOut.BackColor = Color.IndianRed;
            btnHomeNavbarSignOut.Location = new Point(1154, 20);
            btnHomeNavbarSignOut.Name = "btnHomeNavbarSignOut";
            btnHomeNavbarSignOut.Size = new Size(97, 39);
            btnHomeNavbarSignOut.TabIndex = 1;
            btnHomeNavbarSignOut.Text = "Log-ud";
            btnHomeNavbarSignOut.UseVisualStyleBackColor = false;
            btnHomeNavbarSignOut.Click += btnHomeNavbarSignOut_Click;
            // 
            // lblHomeNavbarTitle
            // 
            lblHomeNavbarTitle.AutoSize = true;
            lblHomeNavbarTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblHomeNavbarTitle.Location = new Point(550, 9);
            lblHomeNavbarTitle.Name = "lblHomeNavbarTitle";
            lblHomeNavbarTitle.Size = new Size(113, 28);
            lblHomeNavbarTitle.TabIndex = 0;
            lblHomeNavbarTitle.Text = "Jytte casino";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 22, 28);
            ClientSize = new Size(1263, 653);
            Controls.Add(panelHomePage);
            Controls.Add(panelSignup);
            Controls.Add(panelLogin);
            Name = "Form1";
            Text = "Form1";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelSignup.ResumeLayout(false);
            panelSignup.PerformLayout();
            panelHomePage.ResumeLayout(false);
            panelHomeNavbar.ResumeLayout(false);
            panelHomeNavbar.PerformLayout();
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
        private Button btnHomeNavbarMines;
        private Panel panelHomePage;
        private Panel panelHomeNavbar;
        private Button btnHomeNavbarSignOut;
        private Label lblHomeNavbarTitle;
        private Label lblHomeNavbarCurrency;
        private Label lblHomeNavbarUsername;
        private Button btnHomeNavbarRoulette;
        private Button btnHomeNavbarCrash;
        private Button btnHomeNavbarBlackjack;
    }
}