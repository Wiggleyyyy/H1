// TO DO : BLACK JACK
// TO DO : BETTING IN BLACKJACK - remove from database
// TO DO : CARD FLOW IN BLACKJACK
// TO DO : WINNINGS IN BLACKJACK
// TO DO : NEW BALANCE IN BLACKJACK
// TO DO : TRACK STATS BLACKJACK

using System.CodeDom;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace csharp_gambling
{
    public partial class Form1 : Form
    {
        private Database DB = new Database();
        private Dictionary<Button, Panel> buttonPanelMapLoginSignup;
        private Dictionary<Button, Panel> buttonPanelMapGames;

        //Game data
        private MinesData minesData = new MinesData();
        public BlackJackData blackJackData = new BlackJackData();
        private CrashData crashData = new CrashData();
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
                { btnHomeNavbarBlackjack, panelBlackJack },
                { btnHomeNavbarCrash, panelCrash }
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
        private void textBoxCrashBettingBet_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxCrashBettingBet.Text))
            {
                double balance = DB.GetCurrentBalance(lblHomeNavbarUsername.Text);
                double betInput = (double)Convert.ToDouble(textBoxCrashBettingBet.Text);

                if (balance >= betInput)
                {
                    crashData.MoneyBet = betInput;
                    lblCrashBettingCurrentBet.Text = $"{betInput}kr.";
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
        private void textBoxCrashAutoCashout_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxCrashAutoCashout.Text))
            {
                double betInput = (double)Convert.ToDouble(textBoxCrashAutoCashout.Text);

                crashData.AutoCashOut = betInput;
                lblCrashAutoCashout.Text = $"{betInput}x";
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

                RevealAllMines();

                minesData.GameActive = false;
            }
            else
            {
                MessageBox.Show("Du skal klikke på mindst et felt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrashCashOut_Click(object sender, EventArgs e)
        {

            if (crashData.GameActive)
            {
                if (crashData.CashedOut == false)
                {
                    crashData.CashedOut = true;
                    string winningsInput = lblCrashGameWinnings.Text.Replace("kr.", "");
                    double winnings = (double)Convert.ToDouble(winningsInput);

                    string username = lblHomeNavbarUsername.Text;
                    double currentBalance = DB.GetCurrentBalance(username);
                    double newBalance = currentBalance + winnings;

                    DB.InsertNewBalance(username, newBalance);
                    currentBalance = DB.GetCurrentBalance(username);
                    string balanceToWrite = $"Balance: {currentBalance}kr.";
                    lblHomeNavbarCurrency.Text = balanceToWrite;

                    MessageBox.Show($"Du vandt {winnings}kr.", "Tillykke!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCrashGameWinnings.Text = "0kr.";
                    lblCrashGameMultiplier.Text = "x1.0";

                    crashData.GameActive = false;
                }
                else
                {
                    MessageBox.Show("Du allerede cashoutet", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Spillet er ikke aktivt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCrashBettingPlaceBet_Click(object sender, EventArgs e)
        {
            if (crashData.GameActive == false)
            {
                //Check requirements
                if (crashData.MoneyBet > 0)
                {
                    //Start game
                    Crash();
                }
                else
                {
                    MessageBox.Show("Felter er ikke udfyldt korrekt, eller bet er for lavt.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Gamet er igang", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void comboBoxBlackJackBettingHandsCount_Leave(object sender, EventArgs e)
        {
            lblBlackJackBettingHandCount.Text = comboBoxBlackJackBettingHandsCount.Text.Trim();
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

        private double CalculateMineMultiplier(int numBombs, int clearedFields)
        {
            Dictionary<(int x, int y), double> resultMap = new Dictionary<(int x, int y), double>
            {
                {(1, 3), 1.12},{(2, 3), 1.29},{(3, 3), 1.48},{(4, 3), 1.71},{(5, 3), 2},{(6, 3), 2.35},{(7, 3), 2.79},{(8, 3), 3.35},{(9, 3), 4.07},{(10, 3), 5},{(11, 3), 6.26},{(12, 3), 7.96},{(13, 3), 10.35},{(14, 3), 13.8},{(15, 3), 18.97},{(16, 3), 27.11},{(17, 3), 40.66},{(18, 3), 65.06},{(19, 3), 113.9},{(20, 3), 227.7},{(21, 3), 569.3},{(22, 3), 2277},
                {(1, 4), 1.18},{(2, 4), 1.41},{(3, 4), 1.71},{(4, 4), 2.09},{(5, 4), 2.58},{(6, 4), 3.23},{(7, 4), 4.09},{(8, 4), 5.26},{(9, 4), 6.88},{(10, 4), 9.17},{(11, 4), 12.04},{(12, 4), 17.52},{(13, 4), 25.3},{(14, 4), 37.95},{(15, 4), 59.64},{(16, 4), 99.39},{(17, 4), 178.9},{(18, 4), 357.8},{(19, 4), 834.9},{(20, 4), 2504},{(21, 4), 12523},
                {(1, 5), 1.24},{(2, 5), 1.56},{(3, 5), 2},{(4, 5), 2.58},{(5, 5), 3.39},{(6, 5), 4.52},{(7, 5), 6.14},{(8, 5), 8.5},{(9, 5), 12.04},{(10, 5), 17.52},{(11, 5), 26.27},{(12, 5), 40.87},{(13, 5), 66.41},{(14, 5), 113.9},{(15, 5), 208.7},{(16, 5), 417.5},{(17, 5), 939.3},{(18, 5), 2504},{(19, 5), 8766},{(20, 5), 12523},
                {(1, 6), 1.3},{(2, 6), 1.74},{(3, 6), 2.35},{(4, 6), 3.23},{(5, 6), 4.52},{(6, 6), 6.46},{(7, 6), 9.44},{(8, 6), 14.17},{(9, 6), 21.89},{(10, 6), 35.03},{(11, 6), 58.38},{(12, 6), 102.17},{(13, 6), 189.75},{(14, 6), 379.5},{(15, 6), 834.9},{(16, 6), 2087},{(17, 6), 6261},{(18, 6), 25047},{(19, 6), 175329},
                {(1, 7), 1.37},{(2, 7), 1.94},{(3, 7), 2.79},{(4, 7), 4.09},{(5, 7), 6.14},{(6, 7), 9.44},{(7, 7), 14.95},{(8, 7), 24.47},{(9, 7), 41.6},{(10, 7), 73.95},{(11, 7), 138.66},{(12, 7), 277.33},{(13, 7), 600.87},{(14, 7), 1442},{(15, 7), 3965},{(16, 7), 13219},{(17, 7), 59486},{(18, 7), 475893},
                {(1, 8), 1.46},{(2, 8), 2.18},{(3, 8), 3.35},{(4, 8), 5.26},{(5, 8), 8.5},{(6, 8), 14.17},{(7, 8), 24.47},{(8, 8), 44.05},{(9, 8), 83.2},{(10, 8), 166.4},{(11, 8), 356.56},{(12, 8), 831.98},{(13, 8), 2163},{(14, 8), 6439},{(15, 8), 23794},{(16, 8), 118973},{(17, 8), 1070759},
                {(1, 9), 1.55},{(2, 9), 2.47},{(3, 9), 4.07},{(4, 9), 6.88},{(5, 9), 12.04},{(6, 9), 21.89},{(7, 9), 41.6},{(8, 9), 83.2},{(9, 9), 176.8},{(10, 9), 404.1},{(11, 9), 1010},{(12, 9), 2828},{(13, 9), 9193},{(14, 9), 36773},{(15, 9), 202254},{(16, 9), 2022545},
                {(1, 10), 1.65},{(2, 10), 2.83},{(3, 10), 5},{(4, 10), 9.17},{(5, 10), 17.52},{(6, 10), 35.03},{(7, 10), 73.95},{(8, 10), 166.4},{(9, 10), 404.1},{(10, 10), 1077},{(11, 10), 3232},{(12, 10), 11314},{(13, 10), 49031},{(14, 10), 294188},{(15, 10), 3236072},
                {(1, 11), 1.77},{(2, 11), 3.26},{(3, 11), 6.26},{(4, 11), 12.51},{(5, 11), 26.77},{(6, 11), 58.38},{(7, 11), 138.66},{(8, 11), 356.56},{(9, 11), 1010},{(10, 11), 3232},{(11, 11), 12123},{(12, 11), 56574},{(13, 11), 367735},{(14, 11), 4412826},
                {(1, 12), 1.9},{(2, 12), 3.81},{(3, 12), 7.96},{(4, 12), 17.52},{(5, 12), 40.87},{(6, 12), 102.17},{(7, 12), 277.33},{(8, 12), 831.98},{(9, 12), 2828},{(10, 12), 11314},{(11, 12), 56574},{(12, 12), 396022},{(13, 12), 5148297},
                {(1, 13), 2.06},{(2, 13), 4.5},{(3, 13), 10.35},{(4, 13), 25.3},{(5, 13), 66.41},{(6, 13), 189.75},{(7, 13), 600.87},{(8, 13), 2163},{(9, 13), 9193},{(10, 13), 49031},{(11, 13), 367735},{(12, 13), 5148297},
                {(1, 14), 2.25},{(2, 14), 5.4},{(3, 14), 13.8},{(4, 14), 37.95},{(5, 14), 113.85},{(6, 14), 379.5},{(7, 14), 1442},{(8, 14), 6489},{(9, 14), 36773},{(10, 14), 294188},{(11, 14), 4412826},
                {(1, 15), 2.47},{(2, 15), 6.6},{(3, 15), 18.97},{(4, 15), 59.64},{(5, 15), 208.72},{(6, 15), 834.9},{(7, 15), 3965},{(8, 15), 23794},{(9, 15), 202254},{(10, 15), 3236072},
                {(1, 16), 2.75},{(2, 16), 8.25},{(3, 16), 27.11},{(4, 16), 99.39},{(5, 16), 417.45},{(6, 16), 2087},{(7, 16), 13219},{(8, 16), 118973},{(9, 16), 2022545},
                {(1, 17), 3.09},{(2, 17), 10.61},{(3, 17), 40.66},{(4, 17), 178.91},{(5, 17), 939.26},{(6, 17), 6261},{(7, 17), 59486},{(8, 17), 1070759},
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
                return Math.Round(result, 2);
            }
            else
            {
                // Handle the case when the specified key is not found
                MessageBox.Show("Kan ikke finde multiplier", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
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

            switch (blackJackData.NumberOfHands)
            {
                case 1:
                    {
                        panelBlackJackGameCard1.Visible = true;
                        lblBlackJackGameCard1TotalValue.Text = "";
                        lblBlackJackGameCard1NumOfCards.Text = "";
                        lblBlackJackGameCard1CardType.Text = "";
                        lblBlackJackGameCard1CardRank.Text = "";
                        break;
                    }
                case 2:
                    {
                        panelBlackJackGameCard1.Visible = true;
                        panelBlackJackGameCard2.Visible = true;
                        lblBlackJackGameCard1TotalValue.Text = "";
                        lblBlackJackGameCard1NumOfCards.Text = "";
                        lblBlackJackGameCard1CardType.Text = "";
                        lblBlackJackGameCard1CardRank.Text = "";
                        lblBlackJackGameCard2TotalValue.Text = "";
                        lblBlackJackGameCard2NumOfCards.Text = "";
                        lblBlackJackGameCard2CardType.Text = "";
                        lblBlackJackGameCard2CardRank.Text = "";
                        break;
                    }
                case 3:
                    {
                        panelBlackJackGameCard1.Visible = true;
                        panelBlackJackGameCard2.Visible = true;
                        panelBlackJackGameCard3.Visible = true;
                        lblBlackJackGameCard1TotalValue.Text = "";
                        lblBlackJackGameCard1NumOfCards.Text = "";
                        lblBlackJackGameCard1CardType.Text = "";
                        lblBlackJackGameCard1CardRank.Text = "";
                        lblBlackJackGameCard2TotalValue.Text = "";
                        lblBlackJackGameCard2NumOfCards.Text = "";
                        lblBlackJackGameCard2CardType.Text = "";
                        lblBlackJackGameCard2CardRank.Text = "";
                        lblBlackJackGameCard3TotalValue.Text = "";
                        lblBlackJackGameCard3NumOfCards.Text = "";
                        lblBlackJackGameCard3CardType.Text = "";
                        lblBlackJackGameCard3CardRank.Text = "";
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

            HandStatus temp1 = blackJackData.PlayerHand1Status;
            HandStatus temp2 = blackJackData.PlayerHand2Status;
            HandStatus temp3 = blackJackData.PlayerHand3Status;
            CheckHandStatus(blackJackData.DealerHasBlackJack, blackJackData.PlayerHasBlackJackHand1, ref temp1);
            CheckHandStatus(blackJackData.DealerHasBlackJack, blackJackData.PlayerHasBlackJackHand2, ref temp2);
            CheckHandStatus(blackJackData.DealerHasBlackJack, blackJackData.PlayerHasBlackJackHand3, ref temp3);
            blackJackData.PlayerHand1Status = temp1;
            blackJackData.PlayerHand2Status = temp2;
            blackJackData.PlayerHand3Status = temp3;

            bool hand1StillActive = true;
            bool hand2StillActive = true;
            bool hand3StillActive = true;
            if (blackJackData.PlayerHand1Status == HandStatus.WIN)
            {
                MessageBox.Show("Hånd 1 har vundet!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand1StillActive = false;
                //GO TO PAYOUT METHOD
            }
            else if (blackJackData.PlayerHand1Status == HandStatus.LOSS)
            {
                MessageBox.Show("Hånd 1 har tabt!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand1StillActive = false;
                //END GAME
            }
            else if (blackJackData.PlayerHand1Status == HandStatus.DRAW)
            {
                MessageBox.Show("Uafgjordt på hånd 1", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand1StillActive = false;
                //GO TO PAYOUT METHOD
            }

            if (blackJackData.PlayerHand2Status == HandStatus.WIN)
            {
                MessageBox.Show("Hånd 2 har vundet!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand2StillActive = false;
                //GO TO PAYOUT METHOD
            }
            else if (blackJackData.PlayerHand2Status == HandStatus.LOSS)
            {
                MessageBox.Show("Hånd 2 har tabt!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand2StillActive = false;
                //END GAME
            }
            else if (blackJackData.PlayerHand2Status == HandStatus.DRAW)
            {
                MessageBox.Show("Uafgjordt på hånd 2", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand2StillActive = false;
                //GO TO PAYOUT METHOD
            }

            if (blackJackData.PlayerHand3Status == HandStatus.WIN)
            {
                MessageBox.Show("Hånd 3 har vundet!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand3StillActive = false;
                //GO TO PAYOUT METHOD
            }
            else if (blackJackData.PlayerHand3Status == HandStatus.LOSS)
            {
                MessageBox.Show("Hånd 3 har tabt!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand3StillActive = false;
                //END GAME
            }
            else if (blackJackData.PlayerHand3Status == HandStatus.DRAW)
            {
                MessageBox.Show("Uafgjordt på hånd 3", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hand3StillActive = false;
                //GO TO PAYOUT METHOD
            }

            if (blackJackData.NumberOfHands == 1)
            {
                if (hand1StillActive)
                {
                    blackJackData.HitOrStandHand = "hand 1";
                    blackJackData.HitOrStandIsFirstCard = true;

                    double currentBalance = DB.GetCurrentBalance(username); ;
                    //CHECK IF DOUBLE IS AVAILABLE, if not set false
                    while (true)
                    {
                        BlackJackHitOrStand hitOrStandPopUp = new BlackJackHitOrStand
                        {
                            Visible = false,
                        };
                        hitOrStandPopUp.blackJackData = blackJackData;
                        var dialogResult = hitOrStandPopUp.ShowDialog();
                        blackJackData.HitOrStandIsActive = true;

                        if (blackJackData.HitOrStandAction == HitOrStandAction.HIT)
                        {
                            //ADD
                            GiveCard("hand 1");
                            //CHECK IF BUST
                        }
                        else if (blackJackData.HitOrStandAction == HitOrStandAction.DOUBLE)
                        {
                            //ADD
                            //DOUBLE BET + NEW CARD
                            //CHECK IF BUST

                            break;
                        }
                        else if (blackJackData.HitOrStandAction == HitOrStandAction.STAND)
                        {
                            break;
                        }
                    }
                }
            }
            else if (blackJackData.NumberOfHands == 2)
            {
                if (hand1StillActive)
                {
                    blackJackData.HitOrStandIsFirstCard = true;
                    blackJackData.HitOrStandHand = "hand 1";
                    PlayerHitOrStand();
                }
                if (hand2StillActive)
                {
                    blackJackData.HitOrStandIsFirstCard = true;
                    blackJackData.HitOrStandHand = "hand 2";
                    PlayerHitOrStand();
                }
            }
            else if (blackJackData.NumberOfHands == 3)
            {
                if (hand1StillActive)
                {
                    blackJackData.HitOrStandIsFirstCard = true;
                    blackJackData.HitOrStandHand = "hand 1";
                    PlayerHitOrStand();
                }
                if (hand2StillActive)
                {
                    blackJackData.HitOrStandIsFirstCard = true;
                    blackJackData.HitOrStandHand = "hand 2";
                    PlayerHitOrStand();
                }
                if (hand3StillActive)
                {
                    blackJackData.HitOrStandIsFirstCard = true;
                    blackJackData.HitOrStandHand = "hand 3";
                    PlayerHitOrStand();
                }
            }

            //DEALER EXTRA TURN

            //Winnings

            //Multiplier - standard win = +100% | blackjack win = +150% | draw = money back

            //Reset visuals
        }

        private void GiveCard(string hand)
        {
            if (hand == "dealer")
            {

            }
            else if (hand == "hand 1")
            {
                //test if it gets cards for hand 1
                List<Card> tempHand1Cards = blackJackData.PlayerCards.Where(x => x.CardHand == "1").ToList();
            }
            else if (hand == "hand 2")
            {

            }
            else if (hand == "hand 3")
            {

            }
        }

        private void CheckHandStatus(bool dealerHasBlackJack, bool playerHasBlackJack, ref HandStatus playerHandStatus)
        {
            if (dealerHasBlackJack && playerHasBlackJack)
            {
                playerHandStatus = HandStatus.DRAW;
            }
            else if (!dealerHasBlackJack && playerHasBlackJack)
            {
                playerHandStatus = HandStatus.WIN;
            }
            else if (dealerHasBlackJack && !playerHasBlackJack)
            {
                playerHandStatus = HandStatus.LOSS;
            }
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
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = random.Next(blackJackData.AvailableCards.Count);
                Card randomCard = blackJackData.AvailableCards[randomIndex];

                blackJackData.AvailableCards.Remove(randomCard);
                blackJackData.DealerCards.Add(randomCard);
            }

            int numOfCards = blackJackData.DealerCards.Count;
            int handValue = CalculateHandValue(blackJackData.DealerCards);
            bool hasBlackJack = IsBlackjack(blackJackData.DealerCards);

            if (hasBlackJack)
            {
                blackJackData.DealerHasBlackJack = true;
                lblBlackJackGameDealerTotalValue.Text = "Black Jack";
                lblBlackJackGameDealerTotalValue.Text = $"Kort: {numOfCards}";
                MessageBox.Show("Dealer has black jack", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                lblBlackJackGameDealerTotalValue.Text = "Værdi: ?";
                lblBlackJackGameDealerNumOfCards.Text = $"Kort: {numOfCards}";
            }
        }

        private void PlayerTurn(int hand)
        {
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = random.Next(blackJackData.AvailableCards.Count);
                Card randomCard = blackJackData.AvailableCards[randomIndex];


                if (hand == 1)
                {
                    lblBlackJackGameCard1CardType.Text = randomCard.CardSuit;
                    lblBlackJackGameCard2CardRank.Text = randomCard.CardRank;
                    randomCard.CardHand = "1";
                }
                else if (hand == 2)
                {
                    lblBlackJackGameCard2CardType.Text = randomCard.CardSuit;
                    lblBlackJackGameCard2CardRank.Text = randomCard.CardRank;
                    randomCard.CardHand = "2";
                }
                else if (hand == 3)
                {
                    lblBlackJackGameCard3CardType.Text = randomCard.CardSuit;
                    lblBlackJackGameCard3CardRank.Text = randomCard.CardRank;
                    randomCard.CardHand = "3";
                }

                blackJackData.AvailableCards.Remove(randomCard);
                blackJackData.PlayerCards.Add(randomCard);

                //Give time to see card 
                //Thread.Sleep(2000);
                //FIND DIFF WAY TO SEE CARD BEFORE NEW CARD
            }

            int numOfCards = blackJackData.PlayerCards.Count;
            int handValue = CalculateHandValue(blackJackData.PlayerCards);
            bool hasBlackJack = IsBlackjack(blackJackData.PlayerCards);

            if (hasBlackJack)
            {
                if (hand == 1)
                {
                    blackJackData.PlayerHasBlackJackHand1 = true;
                    lblBlackJackGameCard1TotalValue.Text = "Black Jack";
                    lblBlackJackGameCard1NumOfCards.Text = $"Kort: {numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (hand == 2)
                {
                    blackJackData.PlayerHasBlackJackHand2 = true;
                    lblBlackJackGameCard2TotalValue.Text = "Black Jack";
                    lblBlackJackGameCard2NumOfCards.Text = $"Kort: {numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (hand == 3)
                {
                    blackJackData.PlayerHasBlackJackHand3 = true;
                    lblBlackJackGameCard3TotalValue.Text = "Black Jack";
                    lblBlackJackGameCard3NumOfCards.Text = $"Kort: {numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            else
            {
                if (hand == 1)
                {
                    lblBlackJackGameCard1TotalValue.Text = $"Værdi: {handValue}";
                    lblBlackJackGameCard1NumOfCards.Text = $"Kort: {numOfCards}";
                }
                else if (hand == 2)
                {
                    lblBlackJackGameCard2TotalValue.Text = $"Værdi: {handValue}";
                    lblBlackJackGameCard2NumOfCards.Text = $"Kort: {numOfCards}";
                }
                else if (hand == 3)
                {
                    lblBlackJackGameCard3TotalValue.Text = $"Værdi: {handValue}";
                    lblBlackJackGameCard3NumOfCards.Text = $"Kort: {numOfCards}";
                }
            }
        }

        private void PlayerHitOrStand()
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

            //while (true)
            //{
            //    DialogResult result = MessageBox.Show($"Vil du have et kort mere på hånd {hand}", "Hit eller stå", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (result == DialogResult.Yes)
            //    {
            //        //GET NEW CARD

            //        //CHECK IF BUST
            //    }
            //    else
            //    {
            //        //Dealer turn
            //        break;
            //    }
            //}
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

        //Crash - start

        private async void Crash()
        {
            string username = lblHomeNavbarUsername.Text;
            double balance = DB.GetCurrentBalance(username);
            string betInput = textBoxCrashBettingBet.Text;
            double bet = (double)Convert.ToDouble(betInput);

            if (balance > 0)
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

            crashData.GameActive = true;
            double multiplier = 1.00;

            try
            {
                Random random = new Random();

                bool useAlternativeFormula = random.Next(1, 11) == 1;
                bool useAlternativeFormulaMid = random.Next(1, 4) == 1;
                while (true)
                {
                    // Display the current multiplier
                    label34.Text = $"{multiplier:F2}x";
                    lblCrashGameMultiplier.Text = $"{multiplier:F2}x";

                    lblCrashGameWinnings.Text = $"{Math.Round(multiplier * crashData.MoneyBet, 2)}kr.";


                    if (crashData.AutoCashOut <= multiplier && crashData.CashedOut == false)
                    {
                        crashData.CashedOut = true;

                        string winningsInput = lblCrashGameWinnings.Text.Replace("kr.", "");
                        double winnings = (double)Convert.ToDouble(winningsInput);

                        username = lblHomeNavbarUsername.Text;
                        double currentBalance = DB.GetCurrentBalance(username);
                        double newBalance = currentBalance + winnings;

                        DB.InsertNewBalance(username, newBalance);
                        currentBalance = DB.GetCurrentBalance(username);
                        string balanceToWrite = $"Balance: {currentBalance}kr.";
                        lblHomeNavbarCurrency.Text = balanceToWrite;

                        MessageBox.Show($"Du vandt {winnings}kr.", "Tillykke!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblCrashGameWinnings.Text = "0kr.";
                        lblCrashGameMultiplier.Text = "x1.0";

                        crashData.GameActive = false;
                    }
                    // Adjust increment based on the current multiplier to simulate acceleration
                    double increment = 0.01 * Math.Pow(multiplier, 1);

                    // Increase the multiplier gradually
                    multiplier += increment;

                    await Task.Delay(100);

                    // Calculate the probability of using an alternative formula
                    double crashProbability;

                    if (useAlternativeFormula)
                    {
                        crashProbability = CalculateCrashProbability(random, multiplier, 1);
                    }
                    else
                    {
                        if (useAlternativeFormulaMid)
                        {
                            crashProbability = CalculateCrashProbability(random, multiplier, 2);
                        }
                        else
                        {
                            crashProbability = CalculateCrashProbability(random, multiplier, 0);
                        }
                    }

                    // Simulate the crash if a random number is greater than the crash probability
                    if (random.NextDouble() > crashProbability)
                    {
                        // Simulate the crash by throwing an exception
                        SimulateCrash();
                    }
                }
            }
            catch (Exception ex)
            {
                label34.Text = $"{ex.Message}";
                crashData.GameActive = false;
                crashData.CashedOut = false;
            }
        }

        private static double CalculateCrashProbability(Random random, double multiplier, int id)
        {
            double randomFactor;
            switch (id)
            {
                case 0:
                    randomFactor = random.NextDouble() * 0.5 + 0.85; // THE NORMAL
                    return 1.0 / Math.Pow(multiplier, 0.3) * randomFactor;

                case 1:
                    randomFactor = random.NextDouble() * 0.65 + 1.1; // THE RARE
                    return 1.0 / Math.Pow(multiplier, 0.1) * randomFactor;

                case 2:
                    randomFactor = random.NextDouble() * 0.65 + 1.0; // THE MID
                    return 1.0 / Math.Pow(multiplier, 0.2) * randomFactor;
            }

            return 0;
        }
        private static void SimulateCrash()
        {
            // Simulate a crash by throwing an exception
            throw new ApplicationException("The game has crashed!");
        }

        private void btnBlackJackClose_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Crash - end
        //Game functionality - end
    }
}