using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Program_Regnespil
{
    public class Program
    {
        //Settings
        public static string gamemode = ""; // 1 = addition || 2 = subtraction || 3 = multiplication || 4 = division || 5 = tablePractice || 6 = guessANumber
        public static string difficulty = ""; // 1 = 1-10 || 2 = 1-100 || 3 = 1-1000 || 4 = 1-9999
        public static int score = 0;
        public static int guessMaxNumber = 0;
        public static int guessCounter = 1;
        public static int tableTable = 0;
        public static int tableCounter = 1;

        public static dataToSave data = new dataToSave();


        public static void Main(string[] args)
        {
            //Start program in menu
            while (true)
            {
                mainMenu();
            }
        }

        public static void mainMenu()
        {
            while (true)
            {
                Console.WriteLine("==== Main menu ====");
                Console.WriteLine("1. Play game\n2. Quit");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    if (input == "1" || input.ToLower() == "play game")
                    {
                        Console.WriteLine("==== Choose game mode ====");
                        Console.WriteLine("1. Addition (+)\n2. Subtraction (-)\n3. Multiplication (*)\n4. Division (/)");
                        Console.WriteLine("5. Other\n6. Return to main menu\n"); 
                        input = Console.ReadLine();

                        if (!String.IsNullOrEmpty(input))
                        {
                            switch (input.ToLower())
                            {
                                case "1":
                                case "addition":
                                case "+":
                                    {
                                        //Addition
                                        gamemode = "1";
                                        if (score > 0)
                                        {
                                            saveScoreAsTxt(Operation.addition);
                                        }
                                        break;
                                    }
                                case "2":
                                case "subtraction":
                                case "-":
                                    {
                                        //Subtraction
                                        gamemode = "2";
                                        if (score > 0)
                                        {
                                            saveScoreAsTxt(Operation.subtraction);
                                        }
                                        break;
                                    }
                                case "3":
                                case "multiplication":
                                case "*":
                                    {
                                        //Multiplication
                                        gamemode = "2"; 
                                        if (score > 0)
                                        {
                                            saveScoreAsTxt(Operation.multiplication);
                                        }
                                        break;
                                    }
                                case "4":
                                case "division":
                                case "/":
                                    {
                                        //Division
                                        gamemode = "3";
                                        if (score > 0)
                                        {
                                            saveScoreAsTxt(Operation.division);
                                        }
                                        break;
                                    }
                                case "5":
                                case "other":
                                    {
                                        //Other gamemodes
                                        Console.WriteLine("==== Other gamemodes ====");
                                        Console.WriteLine("1. Table practice\n2. Guess a number"); //Maybe add more
                                        Console.WriteLine("3. Return to main menu\n");
                                        string inputOtherModes = Console.ReadLine();

                                        if (!String.IsNullOrEmpty(inputOtherModes))
                                        {
                                            switch(inputOtherModes.ToLower())
                                            {
                                                case "1":
                                                case "table practice":
                                                    {
                                                        while (true)
                                                        {
                                                            Console.WriteLine("Enter the number of the table you want to practice");
                                                            input = Console.ReadLine();

                                                            if (!String.IsNullOrEmpty(input))
                                                            {
                                                                if (int.TryParse(input, out int table))
                                                                {
                                                                    tableTable = table;
                                                                    gamemode = "5";
                                                                    practiceMultiplicationTable(table);
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    //Error handling
                                                                    Console.WriteLine("Invalid input\n");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //Error handling
                                                                Console.WriteLine("Invalid input\n");
                                                            }
                                                        }
                                                    }
                                                case "2":
                                                case "guess a number":
                                                    {
                                                        while (true)
                                                        {
                                                            Console.WriteLine("Enter the max number");
                                                            input = Console.ReadLine();

                                                            if (!String.IsNullOrEmpty(input))
                                                            {
                                                                if (int.TryParse(input, out int maxValue))
                                                                {
                                                                    guessMaxNumber = maxValue;
                                                                    guessNumberGame(maxValue);
                                                                    
                                                                    while (true)
                                                                    {
                                                                        if (score > 0)
                                                                        {
                                                                            gamemode = "6";
                                                                            saveScoreAsTxt(Operation.guessANumber);
                                                                            return;
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Invalid input\n");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid input\n");
                                                            }
                                                        }
                                                    }
                                            }
                                        }
                                        break;
                                    }
                                case "6":
                                case "Return to main menu":
                                    {
                                        //Returns to main menu
                                        return;
                                    }
                            }

                            //When mode is selected
                            string choice = difficultySelection();
                            if (choice == "selected")
                            {
                                switch(gamemode) // maybe mode table prac and guess here ?
                                {
                                    case "1":
                                        {
                                            playGame(Operation.addition, difficulty);

                                            break;
                                        }
                                    case "2":
                                        {
                                            playGame(Operation.subtraction, difficulty);
                                            break;
                                        }
                                    case "3":
                                        {
                                            playGame(Operation.multiplication, difficulty);
                                            break;
                                        }
                                    case "4":
                                        {
                                            playGame(Operation.division, difficulty);
                                            break;
                                        }
                                    default:
                                        {
                                            //Error handling
                                            Console.WriteLine("Invalid gamemode\n");
                                            break;
                                        }
                                }
                            }
                            else if (choice == "menu")
                            {
                                return;
                            }
                        }
                        else
                        {
                            //Error handling
                            Console.WriteLine("Invalid input\n");
                        }
                    }
                    else if (input == "2" || input.ToLower() == "quit")
                    {
                        //Quit
                        Environment.Exit(0);
                    }
                    else
                    {
                        //Error handling
                        Console.WriteLine("Invalid input\n");
                    }
                }
                else
                {
                    //If input is invalid
                    Console.WriteLine("Invalid input\n");

                    //Repeat main menu loop
                }
            }
        }

        public static string difficultySelection()
        {
            while (true)
            {
                Console.WriteLine("==== Choose difficulty ====");
                Console.WriteLine("1. 1-10\n2. 1-100\n3. 1-1000\n4. 1-9999");
                Console.WriteLine("5. Return to main menu\n");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (input.ToLower())
                    {
                        case "1":
                        case "1-10":
                            {
                                //Difficulty 1
                                difficulty = "1";
                                return "selected";
                            }
                        case "2":
                        case "1-100":
                            {
                                //Difficulty 2
                                difficulty = "2";
                                return "selected";
                            }
                        case "3":
                        case "1-1000":
                            {
                                //Difficulty 3
                                difficulty = "3";
                                return "selected";
                            }
                        case "4":
                        case "1-9999":
                            {
                                //Difficulty 4
                                difficulty = "4";
                                return "selected";
                            }
                        case "5":
                        case "return":
                            {
                                //Return to menu
                                return "menu";
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input\n");
                }
            }
        }

        static void playGame(Operation operation, string difficulty)
        {
            Console.Write($"==== {operation} ====\n");

            int minNumber = 1;
            int maxNumber = 0;

            switch (difficulty)
            {
                case "1":
                    maxNumber = 10;
                    break;
                case "2":
                    maxNumber = 100;
                    break;
                case "3":
                    maxNumber = 1000;
                    break;
                case "4":
                    maxNumber = 9999;
                    break;
                default:
                    //Error handling
                    Console.WriteLine("Invalid difficulty\n");
                    return;
            }

            // Reset score
            score = 0;

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int firstNumber = random.Next(minNumber, maxNumber + 1);
                int secondNumber = random.Next(minNumber, maxNumber + 1);

                string problem = generateProblem(firstNumber, secondNumber, operation);
                Console.Write($"{i + 1}. {problem} = ");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    int userAnswer;
                    if (int.TryParse(input, out userAnswer))
                    {
                        int correctAnswer = calculateAnswer(firstNumber, secondNumber, operation);

                        if (userAnswer == correctAnswer)
                        {
                            Console.WriteLine("Correct\n");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input; Wrong\n");
                }
            }

            Console.WriteLine($"** You scored {score} out of 10 **\n");
            saveScoreAsTxt(operation);

            //Reset settings to prevent loops
            gamemode = "";
            difficulty = "";

            Console.WriteLine("Returning to main menu\n");
        }

        public static string generateProblem(int firstNumber, int secondNumber, Operation operation)
        {
            switch (operation)
            {
                case Operation.addition:
                    {
                        return $"{firstNumber} + {secondNumber}";
                    }
                case Operation.subtraction:
                    {
                        return $"{firstNumber} - {secondNumber}";
                    }
                case Operation.multiplication:
                    {
                        return $"{firstNumber} * {secondNumber}";
                    }
                case Operation.division:
                    {
                        return $"{firstNumber} / {secondNumber}";
                    }
                default:
                    {
                        throw new ArgumentException("Invalid operation\n");
                    }
            }
        }

        public static int calculateAnswer(int firstNumber, int secondNumber, Operation operation)
        {
            switch(operation)
            {
                case Operation.addition:
                    {
                        return firstNumber + secondNumber;
                    }
                case Operation.subtraction:
                    {
                        return firstNumber - secondNumber;
                    }
                case Operation.multiplication:
                    {
                        return firstNumber * secondNumber;
                    }
                case Operation.division:
                    {
                        return firstNumber / secondNumber;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid operation\n");
                    }
            }
        }

        public static void saveScoreAsTxt(Operation operation)
        {
            string mode;
            switch (operation)
            {
                case Operation.addition:
                    {
                        mode = "Addition";
                        break;
                    }
                case Operation.subtraction:
                    {
                        mode = "Subtraction";
                        break;
                    }
                case Operation.multiplication:
                    {
                        mode = "Multiplication";
                        break;
                    }
                case Operation.division:
                    {
                        mode = "Division";
                        break;
                    }
                case Operation.guessANumber:
                    {
                        mode = "Guess a number";
                        break;
                    }
                case Operation.tablePractice:
                    {
                        mode = "Table practice";
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid operation");
                    }
            }

            while (true)
            {
                Console.WriteLine($"Do you want to save score from {mode} as .txt file? (yes/no)");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    if (input.ToLower() == "yes" || input.ToLower() == "y")
                    {
                        //Create directories
                        string autoDirGame = @"C:\Regnespil";
                        string autoDirScores = @"C:\Regnespil\Scores";

                        if (!Directory.Exists(autoDirGame))
                        {
                            Console.WriteLine($"Creating dir ({autoDirGame} + {autoDirScores})");
                            Directory.CreateDirectory(autoDirGame);
                            Directory.CreateDirectory(autoDirScores);
                            Console.WriteLine("Created\n");
                        }
                        else if (!Directory.Exists(autoDirScores))
                        {
                            Console.WriteLine($"Creating dir ({autoDirScores})");
                            Directory.CreateDirectory(autoDirScores);
                            Console.WriteLine("Created\n");
                        }

                        //Set data
                        int maxScore = 0;

                        DateTime currentDateTemp = DateTime.Now;
                        data.date = currentDateTemp.ToString("dd/MM/yyyy");
                        switch (operation)
                        {
                            case Operation.addition:
                                {
                                    data.gamemode = "Addition";
                                    break;
                                }
                            case Operation.subtraction:
                                {
                                    data.gamemode = "Subtraction";
                                    break;
                                }
                            case Operation.multiplication:
                                {
                                    data.gamemode = "Multiplication";
                                    break;
                                }
                            case Operation.division:
                                {
                                    data.gamemode = "Division";
                                    break;
                                }
                            case Operation.guessANumber:
                                {
                                    data.gamemode = "Guess a number";
                                    break;
                                }
                            case Operation.tablePractice:
                                {
                                    data.gamemode = "Table practice";
                                    break;
                                }
                        }
                        if (gamemode != "5" && gamemode != "6")
                        {
                            switch (difficulty)
                            {
                                case "1":
                                    {
                                        data.difficulty = "1-10";
                                        maxScore = 10;
                                        break;
                                    }
                                case "2":
                                    {
                                        data.difficulty = "1-100";
                                        maxScore = 100;
                                        break;
                                    }
                                case "3":
                                    {
                                        data.difficulty = "1-1000";
                                        maxScore = 1000;
                                        break;
                                    }
                                case "4":
                                    {
                                        data.difficulty = "1-9999";
                                        maxScore = 9999;
                                        break;
                                    }
                                default:
                                    {
                                        //Error handling
                                        data.difficulty = "Unavailable";
                                        maxScore = 0;
                                        break;
                                    }
                            }
                        }
                        else if (gamemode == "5")
                        {
                            //Table practice
                            if (tableTable != 0)
                            {
                                data.difficulty = $"table = {tableTable}";
                                maxScore = tableCounter; //Set maxScore as attempts to calculate ratio
                            }
                            else
                            {
                                data.difficulty = "Unavilable";
                            }
                        }
                        else if (gamemode == "6")
                        {
                            //Guess a number
                            data.difficulty = $"1-{guessMaxNumber}";
                            maxScore = guessCounter; //Set maxScore as attempts to calculate ratio
                        }
                        data.score = score;
                        if (maxScore != 0)
                        {
                            string persentageOfScore = calculatePersentageOfScore(score, maxScore).ToString();
                            data.calculatedScore = $"{score}/{maxScore} || {persentageOfScore}%";
                        }
                        else
                        {
                            //Error handling
                            data.calculatedScore = "Unavailable";
                        }

                        //Save data file
                        string fileName = @"C:\Regnespil\Scores\data.txt";

                        if (File.Exists(fileName))
                        {
                            //Create new fileName until one is available
                            string capitalizedMode = data.gamemode.First().ToString().ToUpper() + String.Join("", data.gamemode.Skip(1));
                            string baseFileName = @$"C:\Regnespil\Scores\data{capitalizedMode.Replace(" ", "_")}";
                            string extension = ".txt";
                            int fileIndex = 1;
                            
                            while (File.Exists(fileName))
                            {
                                fileName = $"{baseFileName}{fileIndex}{extension}";
                                fileIndex++;
                            }

                            writeSaveData(fileName);

                            Console.WriteLine(@"Saved successfully at 'C:\Regnespil\Scores'" + "\n");

                            break;
                        }
                        else
                        {
                            writeSaveData(fileName);

                            Console.WriteLine(@"Saved successfully at 'C:\Regnespil\Scores'" + "\n");

                            break;
                        }
                        
                    }
                    else if (input.ToLower() == "no" || input.ToLower() == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input\n");
                    }
                }
                else
                {
                    //Error handling
                    Console.WriteLine("Invalid input\n");
                }
            }
        }

        public static double calculatePersentageOfScore(int correctGuesses, int totalProblems)
        {
            if (totalProblems == 0)
            {
                return 0;
            }
            return (double)correctGuesses / totalProblems * 100;
        }

        public static void writeSaveData(string fileName)
        {
            //Write data
            using (FileStream fs = File.Create(fileName))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Date: " + data.date);
                sw.WriteLine("Gamemode: " + data.gamemode);
                sw.WriteLine("Difficulty: " + data.difficulty);
                sw.WriteLine("Score: " + data.score);
                sw.WriteLine("Percentage: " + data.calculatedScore);
            }
            return;
        }

        public enum Operation
        {
            addition,
            subtraction,
            multiplication,
            division,
            guessANumber,
            tablePractice
        }

        public static void guessNumberGame(int maxValue)
        {
            score = 0;

            while (true)
            {
                Console.WriteLine($"Guess a number between 1-{maxValue}");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out int guess))
                    {
                        Random random = new Random();
                        int correctNumber = random.Next(1, maxValue+1);

                        if (guess == correctNumber)
                        {
                            score++;
                            guessCounter++;
                            Console.WriteLine($"Correct! Score: {score} | play again? (yes/no)");
                        }
                        else
                        {
                            guessCounter++;
                            Console.WriteLine($"Incorrect! Score: {score} | play again? (yes/no)");
                        }

                        input = Console.ReadLine();

                        if (input.ToLower() == "yes" || input.ToLower() == "y")
                        {
                            //Repeats loop
                        }
                        else if (input.ToLower() == "no" || input.ToLower() == "n")
                        {
                            //Returns to mode selection
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, returning to main menu.\n");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input\n");
                }
            }
        }

        public static void practiceMultiplicationTable(int table)
        {
            int multiplicand = 1;
            score = 0;

            while (true)
            {
                string problem = $"{table} x {multiplicand} (to stop, write 'stop')";

                Console.Write($"{multiplicand}. {problem} = ");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out int userAnswer))
                    {
                        int correctAnswer = table * multiplicand;

                        if (userAnswer == correctAnswer)
                        {
                            tableCounter++;
                            score++;
                            multiplicand++;
                            Console.WriteLine($"Correct! Score: {score}\n");
                        }
                        else
                        {
                            tableCounter++;
                            Console.WriteLine($"Incorrect! Score: {score}");
                            Console.WriteLine("Do you want to contine? (yes/no)");
                            input = Console.ReadLine();

                            if (!String.IsNullOrEmpty(input))
                            {
                                if (input.ToLower() == "yes" || input.ToLower() == "y")
                                {
                                    //Repeats loop
                                }
                                else if (input.ToLower() == "no" || input.ToLower() == "n")
                                {
                                    saveScoreAsTxt(Operation.tablePractice);
                                    break;
                                }
                                else
                                {
                                    //Error handling
                                    Console.WriteLine("Invalid input\n");
                                }
                            }
                            else
                            {
                                //Error handling
                                Console.WriteLine("Invalid input\n");
                            }
                        }
                    }
                    else if (input.ToLower() == "stop" || input.ToLower() == "s")
                    {
                        if (score > 0)
                        {
                            saveScoreAsTxt(Operation.tablePractice);
                        }
                        break;
                    }
                    else
                    {
                        //Error handling
                        Console.WriteLine("Invalid input\n");
                    }
                }
                else
                {
                    //Error handling
                    Console.WriteLine("Invalid input\n");
                }
            }
        }
    }

    public class dataToSave
    {
        public string date { get; set; }
        public string gamemode { get; set; }
        public string difficulty { get; set; }
        public int score { get; set; }
        public string calculatedScore { get; set; }
    }
}