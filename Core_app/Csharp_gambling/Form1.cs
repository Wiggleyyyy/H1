//TO DO : LOGIN CHECK DATABASE

//TO DO : CREATE LOGIN DATABASE

namespace csharp_gambling
{
    public partial class Form1 : Form
    {
        public Dictionary<Button, Panel> buttonPanelMapLoginSignup;

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

                //Method to check if password matches database login
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

                //Method to check if login is in database, if not create - else return error
            }
        }
        //Button functionality - end
    }
}