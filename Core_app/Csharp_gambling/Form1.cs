//TO DO : LOGIN CHECK DATABASE

//TO DO : CREATE LOGIN DATABASE

using System.Text.RegularExpressions;

namespace csharp_gambling
{
    public partial class Form1 : Form
    {
        private Database DB = new Database();
        private Dictionary<Button, Panel> buttonPanelMapLoginSignup;

        public Form1()
        {
            InitializeComponent();

            //Login buttons
            InitializeButtonPanelMapLoginSignup();
            InitializeButtonEventsLoginSignup();
        }

        //Initialize - start
        private void InitializeButtonPanelMapLoginSignup()
        {
            buttonPanelMapLoginSignup = new Dictionary<Button, Panel>
            {
                { btnLoginSignup, panelSignup }, //Login panel("Opret konto?") -> signup panel
                { btnSignupLogin, panelLogin } //Signup panel("Log-in?") -> login panel 
                //More ?
            };
        }

        private void InitializeButtonEventsLoginSignup()
        {
            foreach (var pair in buttonPanelMapLoginSignup)
            {
                pair.Key.Click += (sender, e) => SwapPanels(pair.Key);
            }
        }
        //Initialize - end
        private void SwapPanels(Button clickedButton)
        {
            if (buttonPanelMapLoginSignup.ContainsKey(clickedButton))
            {
                Panel targetPanel = buttonPanelMapLoginSignup[clickedButton];
                targetPanel.Visible = true;

                foreach (var pair in buttonPanelMapLoginSignup)
                {
                    if (pair.Key != clickedButton)
                    {
                        pair.Value.Visible = false;
                    }
                }
            }
        }

        //Button functionality - start
        private void btnLoginLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxLoginUsername.Text) && //Check if username is entered
                !String.IsNullOrEmpty(textBoxLoginPassword.Text)) //Check if password is entered
            {
                string username = textBoxLoginUsername.Text;
                string password = textBoxLoginPassword.Text;

                bool isLoggedIn = DB.Login(username, password);
                if (isLoggedIn == true)
                {
                    panelLogin.Visible = false;
                    LoadHomePage();
                }
            }
            else
            {
                MessageBox.Show("Brugernavn og adgangskode ugyldigt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignupCreateAccount_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSignupUsername.Text) && //Check if username is entered
                !String.IsNullOrEmpty(textBoxSignupPassword.Text) && //Check if password is entered)
                textBoxSignupConfirmPassword.Text == textBoxSignupPassword.Text) //Check if password confirm is the same as password
            {
                string username = textBoxSignupUsername.Text;
                string password = textBoxSignupConfirmPassword.Text;

                //Extra requirements for password fx. length of min. 8
                if (PasswordContainsNumber(password) == false && (password.Length >= 8) == false)
                {
                    MessageBox.Show("Adgangskode skal indeholde mindst 1 tal og have mindst 8 karakterer.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isSignedUp = DB.Signup(username, password);
                if (isSignedUp == true)
                {
                    bool isLoggedIn = DB.Login(username, password);
                    if (isLoggedIn == true)
                    {
                        panelSignup.Visible = false;
                        LoadHomePage();
                    }
                }
            }
            else
            {
                MessageBox.Show("Felter ikke udfyldt korrekt.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHomeNavbarSignOut_Click(object sender, EventArgs e)
        {
            lblHomeNavbarUsername.Text = "<BRUGERNAVN>";
            lblHomeNavbarCurrency.Text = "$<CURRENCY>";

            textBoxLoginUsername.Text = "";
            textBoxLoginPassword.Text = "";

            textBoxSignupUsername.Text = "";
            textBoxSignupPassword.Text = "";
            textBoxSignupConfirmPassword.Text = "";

            panelHomePage.Visible = false;
            panelLogin.Visible = true;
        }
        //Button functionality - end

        //Password validation - start
        private bool PasswordContainsNumber(string password)
        {
            string pattern = @"\d"; // \d matches any digit

            Regex regex = new Regex(pattern);

            return regex.IsMatch(password);
        }
        //Password validation - end

        //Loading pages - start
        private void LoadHomePage()
        {
            panelHomePage.Visible = true;

            string username = "";
            decimal balanceFromDatabase = 0;
            string balanceToWrite;

            //Set username
            if (!String.IsNullOrEmpty(textBoxLoginUsername.Text))
            {
                username = textBoxLoginUsername.Text;
            }
            else if (!String.IsNullOrEmpty(textBoxSignupUsername.Text))
            {
                username = textBoxSignupUsername.Text;
            }

            //Check username + get balanceFromDatabase from username
            if (!String.IsNullOrEmpty(username))
            {
                lblHomeNavbarUsername.Text = username;
                balanceFromDatabase = DB.GetCurrentBalance(username);
                if (balanceFromDatabase < 0)
                {
                    balanceToWrite = "Balance: Fejl";
                    lblHomeNavbarCurrency.Text = balanceToWrite;
                    return;
                }

                decimal roundedBalance = Math.Round(balanceFromDatabase, 2);
                balanceToWrite = $"Balance: {roundedBalance}kr.";
                lblHomeNavbarCurrency.Text = balanceToWrite;
            }
            else
            {
                MessageBox.Show("Kunne ikke hente data fra databasen.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelHomePage.Visible = false;
            }
        }
        //Loading pages - end
    }
}