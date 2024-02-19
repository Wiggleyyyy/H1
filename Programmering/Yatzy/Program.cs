using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Yahtzee!");

        Console.Write("Enter the number of players: ");
        int numberOfPlayers = int.Parse(Console.ReadLine());

        List<Player> players = new List<Player>();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Console.Write($"Enter the name of Player {i + 1}: ");
            string playerName = Console.ReadLine();
            players.Add(new Player(playerName));
        }

        YahtzeeGame game = new YahtzeeGame(players);
        game.Play();

        Console.WriteLine("Game Over!");
    }
}

class YahtzeeGame
{
    private List<Player> players;

    public YahtzeeGame(List<Player> players)
    {
        this.players = players;
    }

    public void Play()
    {
        int rounds = 2; // Number of rounds in Yahtzee
        for (int round = 1; round <= rounds; round++)
        {
            Console.WriteLine($"\nRound {round}");
            foreach (var player in players)
            {
                Console.WriteLine($"\n{player.Name}'s turn:");
                player.RollDice();
                player.DisplayDice();
                player.ChooseCategory();
            }
        }

        // Display final scores
        Console.WriteLine("\nFinal Scores:");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.Score}");
        }
    }
}

class Player
{
    public string Name { get; }
    public List<int> Dice { get; private set; }
    public int Score { get; private set; }

    public Player(string name)
    {
        Name = name;
        Dice = new List<int>();
        Score = 0;
    }

    public void RollDice()
    {
        Random random = new Random();
        Dice.Clear();
        for (int i = 0; i < 5; i++)
        {
            Dice.Add(random.Next(1, 7)); // Rolling a six-sided die
        }
    }

    public void DisplayDice()
    {
        Console.WriteLine($"Dice: {string.Join(", ", Dice)}");
    }

    private int remainingRerolls = 2; // Set the maximum number of rerolls

    public void RerollDice()
    {
        if (remainingRerolls > 0)
        {
            Console.WriteLine($"Remaining rerolls: {remainingRerolls}");
            Console.Write("Enter the indices of dice to reroll (e.g., 1 3 5): ");
            string input = Console.ReadLine();

            string[] indices = input.Split(' ');
            bool[] diceToReroll = new bool[5];

            foreach (var index in indices)
            {
                if (int.TryParse(index, out int i) && i >= 1 && i <= 5)
                {
                    diceToReroll[i - 1] = true;
                }
            }

            RollDice(diceToReroll);
            DisplayDice();
            remainingRerolls--;
            RerollDice(); // Allow additional rerolls if remaining
        }
        else
        {
            Console.WriteLine("No more rerolls left.");
        }
    }

    public void ChooseCategory()
    {
        Console.Write("Choose a category (e.g., Ones, Twos, ThreeOfAKind): ");
        string category = Console.ReadLine();

        RerollDice();

        // Update the score based on the chosen category
        switch (category.ToLower())
        {
            case "ones":
                Score += SumOfSameNumber(1);
                break;
            case "twos":
                Score += SumOfSameNumber(2);
                break;
            case "threeofakind":
                Score += ThreeOfAKind();
                break;
            case "fourofakind":
                Score += FourOfAKind();
                break;
            case "fullhouse":
                Score += FullHouse();
                break;
            case "yahtzee":
                if (IsYahtzee())
                {
                    Score += 50; // Yahtzee bonus
                }
                break;
            // Add more cases for other categories
            default:
                Console.WriteLine("Invalid category. Try again.");
                ChooseCategory();
                break;
        }

        Console.WriteLine($"Score for {Name}: {Score}");
    }

    private int CountOccurrences(int value)
    {
        return Dice.Count(d => d == value);
    }

    private int SumOfAllDice()
    {
        return Dice.Sum();
    }

    private int SumOfSameNumber(int number)
    {
        return CountOccurrences(number) * number;
    }

    private int ThreeOfAKind()
    {
        foreach (var value in Dice.Distinct())
        {
            if (CountOccurrences(value) >= 3)
            {
                return SumOfAllDice();
            }
        }
        return 0;
    }

    private int FourOfAKind()
    {
        foreach (var value in Dice.Distinct())
        {
            if (CountOccurrences(value) >= 4)
            {
                return SumOfAllDice();
            }
        }
        return 0;
    }

    private int FullHouse()
    {
        bool hasThreeOfAKind = false;
        bool hasPair = false;

        foreach (var value in Dice.Distinct())
        {
            if (CountOccurrences(value) == 3)
            {
                hasThreeOfAKind = true;
            }
            else if (CountOccurrences(value) == 2)
            {
                hasPair = true;
            }
        }

        if (hasThreeOfAKind && hasPair)
        {
            return 25; // Score for a full house
        }

        return 0;
    }

    public void RollDice(bool[] diceToReroll)
    {
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            if (diceToReroll[i])
            {
                Dice[i] = random.Next(1, 7);
            }
        }
    }

    private bool IsYahtzee()
    {
        return Dice.All(d => d == Dice[0]);
    }
}
