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

        private void btnDeposit_Click(object sender, EventArgs e)
        {
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
            double scaledIncrementFactor = incrementFactor * numBombs / 3.0;

            if (clearedFields == 1)
            {
                return baseMultiplier;
            }
            else
            {
                return Math.Round(baseMultiplier + (clearedFields - 1) * scaledIncrementFactor, 2);
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
                button.Text = field.MineName.Replace("mine", "");
                button.BackColor = default;
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

            //Resets data
            blackJackData.GameActive = true;
            if (blackJackData.PlayerCards != null)
            {
                blackJackData.PlayerCards.Clear();
            }
            if (blackJackData.DealerCards != null)
            {
                blackJackData.DealerCards.Clear();
            }
            blackJackData.Winner = "";

            switch (blackJackData.NumberOfHands)
            {
                case 1:
                    {
                        panelCard1.Visible = true;
                        break;
                    }
                case 2:
                    {
                        panelCard1.Visible = true;
                        panelCard2.Visible = true;
                        break;
                    }
                case 3:
                    {
                        panelCard1.Visible = true;
                        panelCard2.Visible = true;
                        panelCard3.Visible = true;
                        break;
                    }
            }

            SetCards();

            for (int i = 0; i < blackJackData.NumberOfHands; i++)
            {
                int hand = i;
                PlayerTurn(hand);
            }

            //Dealer turn

            //Winnings

            //Multiplier

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

        private void PlayerTurn(int hand)
        {
            //FIND RANDOM CARD
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

            int numOfCards = tempPlayerCards.Count;
            int handValue = CalculateHandValue(blackJackData.PlayerCards);
            bool hasBlackJack = IsBlackjack(blackJackData.PlayerCards);

            if (hasBlackJack)
            {
                if (hand == 1)
                {
                    lblCard1TotalValue.Text = "Black Jack";
                    lblCard1CardsCount.Text = $"{numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (hand == 2)
                {
                    lblCard2TotalValue.Text = "Black Jack";
                    lblCard2CardsCount.Text = $"{numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (hand == 3)
                {
                    lblCard3TotalValue.Text = "Black Jack";
                    lblCard3CardsCount.Text = $"{numOfCards}";
                    MessageBox.Show($"Black Jack on hand {hand}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                blackJackData.Winner = "player";
                return;
            }
            else
            {
                if (handValue > 21)
                {
                    if (hand == 1)
                    {
                        lblCard1TotalValue.Text = "Bust";
                        lblCard1CardsCount.Text = $"{numOfCards}";
                        lblCard1Bust.Visible = true;
                    }
                    else if (hand == 2)
                    {
                        lblCard2TotalValue.Text = "Bust";
                        lblCard2CardsCount.Text = $"{numOfCards}";
                        lblCard2Bust.Visible = true;

                    }
                    else if (hand == 3)
                    {
                        lblCard3TotalValue.Text = "Bust";
                        lblCard3CardsCount.Text = $"{numOfCards}";
                        lblCard3Bust.Visible = true;
                    }

                    blackJackData.Winner = "Dealer";
                    return;
                }

                if (hand == 1)
                {
                    lblCard1TotalValue.Text = $"{handValue}";
                    lblCard1CardsCount.Text = $"{numOfCards}";
                }
                else if (hand == 2)
                {
                    lblCard2TotalValue.Text = $"{handValue}";
                    lblCard2CardsCount.Text = $"{numOfCards}";
                }
                else if (hand == 3)
                {
                    lblCard3TotalValue.Text = $"{handValue}";
                    lblCard3CardsCount.Text = $"{numOfCards}";
                }
            }

            while (true)
            {
                DialogResult result = MessageBox.Show("Vil du have et kort mere?", "Hit eller stå", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    //GET NEW CARD
                }
                else
                {
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