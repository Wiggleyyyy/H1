//TO DO : LOGIN CHECK DATABASE

//TO DO : CREATE LOGIN DATABASE

using System.Text.RegularExpressions;

namespace csharp_gambling
{
    public partial class Form1 : Form
    {
        private Database DB = new Database();
        private Dictionary<Button, Panel> buttonPanelMapLoginSignup;
        private Dictionary<Button, Panel> buttonPanelMapGames;

        //Game data
        public MinesData minesData = new MinesData();

        public Form1()
        {
            InitializeComponent();

            //Login buttons
            InitializeButtonPanelMapLoginSignup();
            InitializeButtonEventsLoginSignup();

            //Navbar games buttons
            InitializeButtonPanelMapGames();
            InitializeButtonEventsGames();

            //Load options into minesCount, starts at 4 ends at 23
            for (int i = 3; i <= 24; i++)
            {
                comboBoxMinesBettingMinesCountCustom.Items.Add($"{i}");
            }
        }

        //Initialize - start
        private void InitializeButtonPanelMapLoginSignup()
        {
            buttonPanelMapLoginSignup = new Dictionary<Button, Panel>
            {
                { btnLoginSignup, panelSignup }, //Login panel("Har du ikke en konto? Opret en") -> signup panel
                { btnSignupLogin, panelLogin } //Signup panel("Log-in?") -> login panel 
            };
        }

        private void InitializeButtonEventsLoginSignup()
        {
            foreach (var pair in buttonPanelMapLoginSignup)
            {
                pair.Key.Click += (sender, e) => SwapPanelsLoginSignup(pair.Key);
            }
        }

        private void InitializeButtonEventsGames()
        {
            foreach (var pair in buttonPanelMapGames)
            {
                pair.Key.Click += (sender, e) => SwapPanelsGames(pair.Key);
            }
        }

        private void InitializeButtonPanelMapGames()
        {
            buttonPanelMapGames = new Dictionary<Button, Panel>
            {
                { btnHomeNavbarMines,  panelHomeMines },
                //add more panels
                //DOING ^^
            };
        }
        //Initialize - end

        //Button functionality - start
        private void SwapPanelsLoginSignup(Button clickedButton)
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

        private void SwapPanelsGames(Button clickedButton)
        {
            if (buttonPanelMapGames.ContainsKey(clickedButton))
            {
                Panel targetPanel = buttonPanelMapGames[clickedButton];

                //Hide panels
                foreach (var panel in buttonPanelMapGames.Values)
                {
                    panel.Visible = false;
                }

                targetPanel.Visible = true;
            }
        }

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

        private void btnMinesClose_Click(object sender, EventArgs e)
        {
            panelHomeMines.Visible = false;
            //Maybe add more?
        }

        private void btnMinesBettingMinesCountMin_Click(object sender, EventArgs e)
        {
            minesData.NumberOfMines = 3;
            lblMinesBettingCurrentMinesCount.Text = "3 bomber";
            comboBoxMinesBettingMinesCountCustom.SelectedItem = null;
        }

        private void btnMinesBettingMinesCountMax_Click(object sender, EventArgs e)
        {
            minesData.NumberOfMines = 24;
            lblMinesBettingCurrentMinesCount.Text = "24 bomber";
            comboBoxMinesBettingMinesCountCustom.SelectedItem = null;
        }

        //ERROR
        //private void comboBoxMinesBettingMinesCountCustom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //int numberOfMines = (int)Convert.ToInt16(comboBoxMinesBettingMinesCountCustom.Text);
        //    //minesData.NumberOfMines = numberOfMines;
        //    //lblMinesBettingCurrentMinesCount.Text = $"{numberOfMines} bomber";

        //    if (int.TryParse(comboBoxMinesBettingMinesCountCustom.Text, out int numberOfMines))
        //    {
        //        minesData.NumberOfMines = numberOfMines;
        //        lblMinesBettingCurrentMinesCount.Text = $"{numberOfMines} bomber";
        //    }
        //}

        private void comboBoxMinesBettingMinesCountCustom_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMinesBettingMinesCountCustom.Text, out int numberOfMines))
            {
                minesData.NumberOfMines = numberOfMines;
                lblMinesBettingCurrentMinesCount.Text = $"{numberOfMines} bomber";
            }
        }

        private void textBoxMinesBettingBet_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxMinesBettingBet.Text))
            {
                double balance = DB.GetCurrentBalance(lblHomeNavbarUsername.Text);
                double betInput = (double)Convert.ToDouble(textBoxMinesBettingBet.Text);

                if (balance > betInput)
                {
                    minesData.MoneyBet = betInput;
                    lblMinesBettingCurrentBet.Text = $"{betInput}kr.";
                    textBoxMinesBettingBet.TextAlign = HorizontalAlignment.Right;
                }
                else
                {
                    MessageBox.Show("Ugyldigt bet.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxMinesBettingBet.TextAlign = HorizontalAlignment.Left;
                textBoxMinesBettingBet.Text = "";
            }
        }

        private void btnMinesBettingClear_Click(object sender, EventArgs e)
        {
            lblMinesBettingCurrentBet.Text = "0 kr.";
            lblMinesBettingCurrentMinesCount.Text = "0 bomber";

            textBoxMinesBettingBet.Text = "";
            comboBoxMinesBettingMinesCountCustom.SelectedItem = null;
        }

        private void btnMinesBettingPlaceBet_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Money bet: " + minesData.MoneyBet + " Number of mines: " + minesData.NumberOfMines);

            //Check requirements
            if (minesData.MoneyBet > 0 && minesData.NumberOfMines >= 3)
            {
                //Start game
                MinesGame();
            }
            else
            {
                MessageBox.Show("Felter er ikke udfyldt korrekt.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            double balanceFromDatabase = 0;
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

                double roundedBalance = Math.Round(balanceFromDatabase, 2);
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

        //Game funcionality - start
        private void MinesGame()
        {
            //minesData.GameActive = true;

            //Random random = new Random();
            //List<int> minePositions = new List<int>();

            //for (int i = 0; i < minesData.NumberOfMines; i++)
            //{
            //    int minePosition;
            //    do
            //    {
            //        minePosition = random.Next(25); // Assuming a 5x5 grid
            //    } while (minePositions.Contains(minePosition));

            //    minePositions.Add(minePosition);
            //}

            //int mineID = 1; // Start mine IDs from 1

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        char bogstav = (char)('A' + i);
            //        string mineName = $"mine{bogstav}{j}";

            //        Field mineField = new Field
            //        {
            //            MineID = mineID++,
            //            IsMine = minePositions.Contains(i * 5 + j)
            //        };

            //        minesData.Fields.Add(mineField);

            //    }      
            //}

            minesData.GameActive = true;

            Random random = new Random();
            List<int> minePositions = new List<int>();

            int gridSize = 5;
            int totalCells = gridSize * gridSize;

            for (int i = 0; i < minesData.NumberOfMines; i++)
            {
                int minePosition;
                do
                {
                    minePosition = random.Next(totalCells);
                } while (minePositions.Contains(minePosition));

                minePositions.Add(minePosition);
            }

            int mineID = 1;
            List<Field> tempFields = new List<Field>();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    char rowChar = (char)('A' + i);
                    int column = j + 1;
                    string mineName = $"mine{rowChar}{column}";

                    Field mineField = new Field
                    {
                        MineID = mineID++,
                        IsMine = minePositions.Contains(i * gridSize + j)
                    };

                    tempFields.Add(mineField);
                }
            }

            if (tempFields.Count > 0)
            {
                minesData.Fields = tempFields;
            }
        }

        private void btnMinesMine_Click(object sender, EventArgs e)
        {
            if (minesData.GameActive)
            {

            }
            else
            {
                MessageBox.Show("Gamet er ikke startet", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Game functionality - end
    }
}