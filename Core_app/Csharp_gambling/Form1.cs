//TO DO : TABINDEX MINES
//TO DO : MINES MULTIPLIER REWORK
//TO DO : TRACK STATS MINES

// TO DO : BLACK JACK
// TO DO : BETTING IN BLACKJACK - remove from database
// TO DO : CARD FLOW IN BLACKJACK
// TO DO : WINNINGS IN BLACKJACK
// TO DO : NEW BALANCE IN BLACKJACK
// TO DO : TRACK STATS BLACKJACK

using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace csharp_gambling
{
    public partial class Form1 : Form
    {
        private Database DB = new Database();
        private Dictionary<Button, Panel> buttonPanelMapLoginSignup;
        private Dictionary<Button, Panel> buttonPanelMapGames;

        //Game data
        private MinesData minesData = new MinesData();
        private BlackJackData blackJackData = new BlackJackData();
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

            //Load options into handsCount, starts at 1 ends at 3
            for (int i = 1; i <= 3; i++)
            {
                comboBoxBlackJackBettingHandsCount.Items.Add($"{i}");
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
                { btnHomeNavbarBlackjack, panelBlackJack }
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
            textBoxLoginUsername.Text = "";
            textBoxLoginPassword.Text = "";

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
        }

        private void btnBlackJackClose_Click(object sender, EventArgs e)
        {
            panelBlackJack.Visible = false;
        }

        private void btnMinesBettingMinesCountMin_Click(object sender, EventArgs e)
        {
            minesData.NumberOfMines = 3;
            lblMinesBettingCurrentMinesCount.Text = "3 bomber";
            comboBoxMinesBettingMinesCountCustom.SelectedItem = null;
            comboBoxMinesBettingMinesCountCustom.Text = "3";
        }

        private void btnMinesBettingMinesCountMax_Click(object sender, EventArgs e)
        {
            minesData.NumberOfMines = 24;
            lblMinesBettingCurrentMinesCount.Text = "24 bomber";
            comboBoxMinesBettingMinesCountCustom.SelectedItem = null;
            comboBoxMinesBettingMinesCountCustom.Text = "24";
        }

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

                if (balance >= betInput)
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
                MessageBox.Show("Felter er ikke udfyldt korrekt, eller bet er for lavt.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBlackJackBettingBet_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxBlackJackBettingBet.Text))
            {
                double balance = DB.GetCurrentBalance(lblHomeNavbarUsername.Text);
                double betInput = (double)Convert.ToDouble(textBoxBlackJackBettingBet.Text);

                if (balance >= betInput)
                {
                    blackJackData.MoneyBet = betInput;
                    lblBlackJackBettingBet.Text = $"{betInput}kr.";
                    textBoxBlackJackBettingBet.TextAlign = HorizontalAlignment.Right;
                }
                else
                {
                    MessageBox.Show("Ugyldigt bet.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxMinesBettingBet.TextAlign = HorizontalAlignment.Left;
                textBoxBlackJackBettingBet.Text = "";
            }
        }

        private void TextBoxBetting_OnlyInputDigits(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnMinesCashOut_Click(object sender, EventArgs e)
        {
            if (minesData.Fields.Where(x => x.IsRevealed == true).Count() > 0)
            {
                string winningsInput = lblMinesGameWinnings.Text.Replace("kr.", "");
                double winnings = (double)Convert.ToDouble(winningsInput);

                string username = lblHomeNavbarUsername.Text;
                double currentBalance = DB.GetCurrentBalance(username);
                double newBalance = currentBalance + winnings;

                DB.InsertNewBalance(username, newBalance);
                currentBalance = DB.GetCurrentBalance(username);
                string balanceToWrite = $"Balance: {currentBalance}kr.";
                lblHomeNavbarCurrency.Text = balanceToWrite;

                MessageBox.Show($"Du vandt {winnings}kr.", "Tillykke!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMinesGameWinnings.Text = "0kr.";
                lblMinesGameMultiplier.Text = "x1.0";
            }
            else
            {
                MessageBox.Show("Du skal klikke på mindst et felt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBlackJackBettingBet_Click(object sender, EventArgs e)
        {
            string username = lblHomeNavbarUsername.Text;
            double bet = (double)Convert.ToDouble(textBoxBlackJackBettingBet.Text);
            double balance = DB.GetCurrentBalance(username);
            string numOfHandsInput = comboBoxBlackJackBettingHandsCount.Text;
            int numOfHands = 1;

            if (!String.IsNullOrEmpty(numOfHandsInput))
            {
                numOfHands = (int)Convert.ToInt32(numOfHandsInput);
            }
            else
            {
                MessageBox.Show("Forkert input i hands", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (balance >= bet && bet >= 0)
            {
                blackJackData.MoneyBet = bet;
                blackJackData.NumberOfHands = numOfHands;
                BlackJackGame();
            }
            else
            {
                MessageBox.Show("Bet er for lavt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Withdraw and deposit - start
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            WithdrawDepositText.Show();
            WithdrawSubmitbutton.Show();

            DepositSubmitbutton.Hide();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            WithdrawDepositText.Show();
            DepositSubmitbutton.Show();

            WithdrawSubmitbutton.Hide();
        }

        private void btnWithdrawSubmit_Click(object sender, EventArgs e)
        {
            WithdrawDepositText.Hide();
            WithdrawSubmitbutton.Hide();
            try
            {
                string username = lblHomeNavbarUsername.Text;
                double balance = DB.GetCurrentBalance(username);
                string WithdrawInput = WithdrawDepositText.Text;
                double Witdraw = (double)Convert.ToDouble(WithdrawInput);

                if (Witdraw >= 0 && balance >= Witdraw)
                {
                    balance -= Witdraw;
                    DB.InsertNewBalance(username, balance);
                }
                double roundedBalance = Math.Round(balance, 2);
                string balanceToWrite = $"Balance: {roundedBalance}kr.";
                lblHomeNavbarCurrency.Text = balanceToWrite;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunne ikke hente data fra databasen.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelHomePage.Visible = false;
            }
        }

        private void btnDepositSubmit_Click(object sender, EventArgs e)
        {
            WithdrawDepositText.Hide();
            DepositSubmitbutton.Hide();
            try
            {
                string username = lblHomeNavbarUsername.Text;
                double balance = DB.GetCurrentBalance(username);
                string DepositInput = WithdrawDepositText.Text;
                double Deposit = (double)Convert.ToDouble(DepositInput);

                if (Deposit >= 0)
                {
                    balance += Deposit;
                    DB.InsertNewBalance(username, balance);
                }
                double roundedBalance = Math.Round(balance, 2);
                string balanceToWrite = $"Balance: {roundedBalance}kr.";
                lblHomeNavbarCurrency.Text = balanceToWrite;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunne ikke hente data fra databasen.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelHomePage.Visible = false;
            }
        }
        //Withdraw and deposit - end


        //Game funcionality - start
        //Mines - start
        private void MinesGame()
        {
            minesData.GameActive = true;
            minesData.CleardFields = 0;

            string username = lblHomeNavbarUsername.Text;
            double balance = DB.GetCurrentBalance(username);
            string betInput = textBoxMinesBettingBet.Text;
            double bet = (double)Convert.ToDouble(betInput);

            if (balance != 0)
            {
                double currentBalance = DB.GetCurrentBalance(username);
                double newBalance = currentBalance - bet;

                DB.InsertNewBalance(username, newBalance);
                currentBalance = DB.GetCurrentBalance(username);
                string balanceToWrite = $"Balance: {currentBalance}kr.";
                lblHomeNavbarCurrency.Text = balanceToWrite;
            }
            else
            {
                MessageBox.Show("Balance er for lavt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            GetGridPositionFromMines();
            HideMines();
        }

        private void btnMinesMine_Click(object sender, EventArgs e)
        {
            if (minesData.GameActive == true)
            {
                Button clickedButton = (Button)sender;

                string buttonName = clickedButton.Name;

                int rowIndex = buttonName[4] - 'A';
                int columnIndex = int.Parse(buttonName.Substring(5)) - 1;

                int position = rowIndex * 5 + columnIndex;

                if (minesData.Fields[position].IsMine == true)
                {
                    //Is mine
                    clickedButton.Enabled = false;
                    clickedButton.Text = "*";
                    clickedButton.ForeColor = Color.DarkRed;
                    clickedButton.BackColor = Color.Red;

                    Field currentField = minesData.Fields.Where(x => x.MineName == clickedButton.Name).FirstOrDefault();
                    currentField.IsRevealed = true;

                    RevealAllMines();

                    lblMinesGameWinnings.Text = "0kr.";
                    lblMinesGameMultiplier.Text = "x1.0";

                    minesData.GameActive = false;
                }
                else
                {
                    //Safe
                    clickedButton.Enabled = false;
                    clickedButton.Text = "Safe";
                    clickedButton.BackColor = Color.Green;

                    minesData.CleardFields++;

                    double multiplier = CalculateMineMultiplier(minesData.NumberOfMines, minesData.CleardFields);
                    lblMinesGameMultiplier.Text = $"x{multiplier}";

                    double bet = minesData.MoneyBet;
                    double winnings = bet * multiplier;
                    lblMinesGameWinnings.Text = $"{Math.Round(winnings, 2)}kr.";

                    Field currentField = minesData.Fields.Where(x => x.MineName == clickedButton.Name).FirstOrDefault();
                    currentField.IsRevealed = true;
                }
            }
            else
            {
                MessageBox.Show("Gamet er ikke startet", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateMineMultiplier(int numBombs, int clearedFields, double baseMultiplier = 1, double incrementFactor = 0.2)
        {
            Dictionary<(int x, int y), double> resultMap = new Dictionary<(int x, int y), double>
            {
                {(1, 3), 1.12},{(2, 3), 1.29},{(3, 3), 1.48},{(4, 3), 1.71},{(5, 3), 2},{(6, 3), 2.35},{(7, 3), 2.79},{(8, 3), 3.35},{(9, 3), 4.07},{(10, 3), 5},{(11, 3), 6.26},{(12, 3), 7.96},{(13, 3), 10.35},{(14, 3), 13.8},{(15, 3), 18.97},{(16, 3), 27.11},{(17, 3), 40.66},{(18, 3), 65.06},{(19, 3), 113.9},{(20, 3), 227.7},{(21, 3), 569.3},{(22, 3), 2277},
                {(1, 4), 1.18},{(2, 4), 1.41},{(3, 4), 1.71},{(4, 4), 2.09},{(5, 4), 2.58},{(6, 4), 3.23},{(7, 4), 4.09},{(8, 4), 5.26},{(9, 4), 6.88},{(10, 4), 9.17},{(11, 4), 12.04},{(12, 4), 17.52},{(13, 4), 25.3},{(14, 4), 37.95},{(15, 4), 59.64},{(16, 4), 99.39},{(17, 4), 178.9},{(18, 4), 357.8},{(19, 4), 834.9},{(20, 4), 2504},{(21, 4), 12523},
                {(1, 5), 1.24},{(2, 5), 1.56},{(3, 5), 2},{(4, 5), 2.58},{(5, 5), 3.39},{(6, 5), 4.52},{(7, 5), 6.14},{(8, 5), 8.5},{(9, 5), 12.04},{(10, 5), 17.52},{(11, 5), 26.27},{(12, 5), 40.87},{(13, 5), 66.41},{(14, 5), 113.9},{(15, 5), 208.7},{(16, 5), 417.5},{(17, 5), 939.3},{(18, 5), 2504},{(19, 5), 8766},{(20, 5), 12523},
                {(1, 6), 1.3},{(2, 6), 1.74},{(3, 6), 2.35},{(4, 6), 3.23},{(5, 6), 4.52},{(6, 6), 6.46},{(7, 6), 9.44},{(8, 6), 14.17},{(9, 6), 21.89},{(10, 6), 35.03},{(11, 6), 58.38},{(12, 6), 102.17},{(13, 6), 189.75},{(14, 6), 379.5},{(15, 6), 834.9},{(16, 6), 2087},{(17, 6), 6261},{(18, 6), 25047},{(19, 6), 175329},


                {(1, 18), 3.54},{(2, 18), 14.14},{(3, 18), 65.06},{(4, 18), 357.81},{(5, 18), 2504},{(6, 18), 25047},{(7, 18), 475893},
                {(1, 19), 4.12},{(2, 19), 19.8},{(3, 19), 113.85},{(4, 19), 834.9},{(5, 19), 8768},{(6, 19), 175329},
                {(1, 20), 4.95},{(2, 20), 29.7},{(3, 20), 227.7},{(4, 20), 2504},{(5, 20), 52598},
                {(1, 21), 6.19},{(2, 21), 49.5},{(3, 21), 569.3},{(4, 21), 12523},
                {(1, 22), 8.25},{(2, 22), 99},{(3, 22), 2277},
                {(1, 23), 12.37},{(2, 23), 297},
                {(1, 24), 24.75},
            };

            if (resultMap.TryGetValue((clearedFields, numBombs), out double result))
            {
                return Math.Round(result * baseMultiplier, 2);
            }
            else
            {
                // Handle the case when the input is not found in the dictionary
                MessageBox.Show("Kunne ikke calculate multiplier", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // You can choose a default value or handle it differently
            }

        }

        private void RevealAllMines()
        {
            foreach (Field field in minesData.Fields)
            {
                if (field.IsRevealed == false)
                {
                    Button button = FindButtonByName(this, field.MineName);

                    if (field.IsMine == true)
                    {
                        if (button.Enabled == true)
                        {
                            button.Enabled = false;
                        }
                        button.Text = "*";
                        button.ForeColor = Color.DarkRed;
                        button.BackColor = Color.Red;
                        field.IsRevealed = true;
                    }
                    else
                    {
                        if (button.Enabled == true)
                        {
                            button.Enabled = false;
                        }
                        button.Text = "Safe";
                        button.BackColor = Color.Green;
                        field.IsRevealed = true;
                    }
                }
            }
        }

        private void HideMines()
        {
            foreach (Field field in minesData.Fields)
            {
                Button button = FindButtonByName(this, field.MineName);

                button.Enabled = true;
                //button.Text = field.MineName.Replace("mine", "");
                button.BackColor = Color.FromArgb(24, 22, 28);
                button.ForeColor = Color.FromArgb(41, 38, 49);
                button.Text = "?";
                field.IsRevealed = false;
            }
        }

        private Button FindButtonByName(Control parent, string name)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button && button.Name == name)
                {
                    return button;
                }
                else if (control.HasChildren)
                {
                    Button childButton = FindButtonByName(control, name);
                    if (childButton != null)
                    {
                        return childButton;
                    }
                }
            }
            return null;
        }

        private void GetGridPositionFromMines()
        {
            List<Button> minesButtons = new List<Button>();

            int row = 1;
            string rowChar = "";
            for (int i = 0; i < 25; i++)
            {
                if (i % 5 == 0 && i > 0)
                {
                    row++;
                }

                int column = (i % 5) + 1;

                switch (row)
                {
                    case 1:
                        {
                            rowChar = "A";
                            break;
                        }
                    case 2:
                        {
                            rowChar = "B";
                            break;
                        }
                    case 3:
                        {
                            rowChar = "C";
                            break;
                        }
                    case 4:
                        {
                            rowChar = "D";
                            break;
                        }
                    case 5:
                        {
                            rowChar = "E";
                            break;
                        }
                }

                if (!String.IsNullOrEmpty(rowChar))
                {
                    string mineName = $"mine{rowChar}{column}";

                    Field field = minesData.Fields[i];
                    field.MineName = mineName;
                }
            }
        }
        //Mines - end

        //Blackjack - start
        private void BlackJackGame()
        {
            string username = lblHomeNavbarUsername.Text;
            double balance = DB.GetCurrentBalance(username);
            double bet = (double)Convert.ToDouble(textBoxBlackJackBettingBet.Text);
            double newBalance = balance - bet;

            //EDIT BALANCE

            //Reset data
            blackJackData.GameActive = true;
            if (blackJackData.PlayerCards != null)
            {
                blackJackData.PlayerCards.Clear();
            }
            if (blackJackData.DealerCards != null)
            {
                blackJackData.DealerCards.Clear();
            }
            blackJackData.Win = "";

            switch (blackJackData.NumberOfHands)
            {
                case 1:
                    {
                        panelBlackJackGameCard1.Visible = true;
                        lblCard1TotalValue.Text = "";
                        lblCard1CardsCount.Text = "";
                        lblCard1CardType.Text = "";
                        lblCard1CardValue.Text = "";
                        break;
                    }
                case 2:
                    {
                        panelBlackJackGameCard1.Visible = true;
                        panelBlackJackGameCard2.Visible = true;
                        lblCard1TotalValue.Text = "";
                        lblCard1CardsCount.Text = "";
                        lblCard1CardType.Text = "";
                        lblCard1CardValue.Text = "";
                        lblCard2TotalValue.Text = "";
                        lblCard2CardsCount.Text = "";
                        lblCard2CardType.Text = "";
                        lblCard2CardValue.Text = "";
                        break;
                    }
                case 3:
                    {
                        panelBlackJackGameCard1.Visible = true;
                        panelBlackJackGameCard2.Visible = true;
                        panelBlackJackGameCard3.Visible = true;
                        lblCard1TotalValue.Text = "";
                        lblCard1CardsCount.Text = "";
                        lblCard1CardType.Text = "";
                        lblCard1CardValue.Text = "";
                        lblCard2TotalValue.Text = "";
                        lblCard2CardsCount.Text = "";
                        lblCard2CardType.Text = "";
                        lblCard2CardValue.Text = "";
                        lblCard3TotalValue.Text = "";
                        lblCard3CardsCount.Text = "";
                        lblCard3CardType.Text = "";
                        lblCard3CardValue.Text = "";
                        break;
                    }
            }

            SetCards();

            int hand = 0;
            for (int i = 0; i < blackJackData.NumberOfHands; i++)
            {
                hand = i + 1;
                PlayerTurn(hand);
            }

            DealerTurn();

            //Check for blackjacks
            //Loop through each hand

            //Extra turns

            //Winnings

            //Multiplier - standard win = +100% | blackjack win = +150%

            //Reset visuals
        }

        private void SetCards()
        {
            if (blackJackData.AvailableCards != null)
            {
                blackJackData.AvailableCards.Clear();
            }

            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            List<Card> tempAvailableCards = new List<Card>();

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    string cardName = $"{rank} of {suit}";

                    Card card = new Card
                    {
                        CardName = cardName,
                        CardSuit = suit,
                        CardRank = rank,
                        CardHand = "Deck",
                    };

                    tempAvailableCards.Add(card);
                }
            }

            if (tempAvailableCards.Count > 0)
            {
                blackJackData.AvailableCards = tempAvailableCards;
            }
        }

        private void DealerTurn()
        {
            List<Card> tempAvailableCards = blackJackData.AvailableCards;
            List<Card> tempDealerCards = new List<Card>();

            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = random.Next(tempAvailableCards.Count);
                Card randomCard = tempAvailableCards[randomIndex];

                tempAvailableCards.Remove(randomCard);
                tempDealerCards.Add(randomCard);
            }

            blackJackData.AvailableCards = tempAvailableCards;
            blackJackData.DealerCards = tempDealerCards;

            int numOfCards = tempDealerCards.Count;
            int handValue = CalculateHandValue(blackJackData.DealerCards);
            bool hasBlackJack = IsBlackjack(blackJackData.DealerCards);

            if (hasBlackJack)
            {
                blackJackData.DealerHasBlackJack = true;
                lblDealerTotalValue.Text = "Black Jack";
                lblDealerTotalValue.Text = $"Kort: {numOfCards}";
                MessageBox.Show("Dealer has black jack", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                lblDealerTotalValue.Text = "Værdi: ?";
                lblDealerCardsCount.Text = $"Kort: {numOfCards}";
            }            
        }

        private void PlayerTurn(int hand)
        {
            List<Card> tempAvailableCards = blackJackData.AvailableCards;
            List<Card> tempPlayerCards = new List<Card>();

            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = random.Next(tempAvailableCards.Count);
                Card randomCard = tempAvailableCards[randomIndex];

                if (hand == 1)
                {
                    lblCard1CardType.Text = randomCard.CardSuit;
                    lblCard1CardValue.Text = randomCard.CardRank;
                    randomCard.CardHand = "1";
                }
                else if (hand == 2)
                {
                    lblCard2CardType.Text = randomCard.CardSuit;
                    lblCard2CardValue.Text = randomCard.CardRank;
                    randomCard.CardHand = "2";
                }
                else if (hand == 3)
                {
                    lblCard3CardType.Text = randomCard.CardSuit;
                    lblCard3CardValue.Text = randomCard.CardRank;
                    randomCard.CardHand = "3";
                }

                tempAvailableCards.Remove(randomCard);
                tempPlayerCards.Add(randomCard);

                //Give time to see card 
                Thread.Sleep(2000);
            }

            blackJackData.AvailableCards = tempAvailableCards;
            blackJackData.PlayerCards = tempPlayerCards;

            int numOfCards = tempPlayerCards.Count;
            int handValue = CalculateHandValue(blackJackData.PlayerCards);
            bool hasBlackJack = IsBlackjack(blackJackData.PlayerCards);

            if (hasBlackJack)
            {
                if (hand == 1)
                {
                    blackJackData.PlayerHasBlackJackHand1 = true;
                    lblCard1TotalValue.Text = "Black Jack";
                    lblCard1CardsCount.Text = $"Kort: {numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (hand == 2)
                {
                    blackJackData.PlayerHasBlackJackHand2 = true;
                    lblCard2TotalValue.Text = "Black Jack";
                    lblCard2CardsCount.Text = $"Kort: {numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (hand == 3)
                {
                    blackJackData.PlayerHasBlackJackHand3 = true;
                    lblCard3TotalValue.Text = "Black Jack";
                    lblCard3CardsCount.Text = $"Kort: {numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            else
            {
                if (hand == 1)
                {
                    lblCard1TotalValue.Text = $"Værdi: {handValue}";
                    lblCard1CardsCount.Text = $"Kort: {numOfCards}";
                }
                else if (hand == 2)
                {
                    lblCard2TotalValue.Text = $"Værdi: {handValue}";
                    lblCard2CardsCount.Text = $"Kort: {numOfCards}";
                }
                else if (hand == 3)
                {
                    lblCard3TotalValue.Text = $"Værdi: {handValue}";
                    lblCard3CardsCount.Text = $"Kort: {numOfCards}";
                }
            }
        }

        private void PlayerHitOrStand(int hand)
        {
            //if (handValue > 21)
            //{
            //    if (hand == 1)
            //    {
            //        lblCard1TotalValue.Text = "Bust";
            //        lblCard1CardsCount.Text = $"Kort: {numOfCards}";
            //        lblCard1Bust.Visible = true;
            //    }
            //    else if (hand == 2)
            //    {
            //        lblCard2TotalValue.Text = "Bust";
            //        lblCard2CardsCount.Text = $"Kort: {numOfCards}";
            //        lblCard2Bust.Visible = true;

            //    }
            //    else if (hand == 3)
            //    {
            //        lblCard3TotalValue.Text = "Bust";
            //        lblCard3CardsCount.Text = $"Kort: {numOfCards}";
            //        lblCard3Bust.Visible = true;
            //    }

            //    blackJackData.Win = "Dealer";
            //    return;
            //}

            while (true)
            {
                DialogResult result = MessageBox.Show($"Vil du have et kort mere på hånd {hand}", "Hit eller stå", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //GET NEW CARD

                    //CHECK IF BUST
                }
                else
                {
                    //Dealer turn
                    break;
                }
            }
        }

        private int CalculateHandValue(List<Card> hand)
        {
            int totalValue = 0;
            int aceCount = 0;

            foreach (Card card in hand)
            {
                if (card.CardRank.ToLower() == "ace")
                {
                    aceCount++;
                    totalValue += 11; // Assume Ace is 11 initially
                }
                else
                {
                    switch (card.CardRank.ToLower())
                    {
                        case "jack":
                        case "queen":
                        case "king":
                            totalValue += 10;
                            break;
                        default:
                            totalValue += int.Parse(card.CardRank);
                            break;
                    }
                }
            }

            while (totalValue > 21 && aceCount > 0)
            {
                totalValue -= 10; // Adjusting an Ace from 11 to 1
                aceCount--;
            }

            return totalValue;
        }

        private bool IsBlackjack(List<Card> hand)
        {
            if (hand.Count == 2)
            {
                Card firstCard = hand[0];
                Card secondCard = hand[1];
                bool firstCardIsAceOrTen = (firstCard.CardRank.ToLower() == "ace") || ("10,jack,queen,king".Contains(firstCard.CardRank.ToLower()));
                bool secondCardIsAceOrTen = (secondCard.CardRank.ToLower() == "ace") || ("10,jack,queen,king".Contains(secondCard.CardRank.ToLower()));

                return firstCardIsAceOrTen && secondCardIsAceOrTen && (firstCard.CardRank != secondCard.CardRank);
            }

            return false;
        }
        //Blackjack - end
        //Game functionality - end
    }
}