using System;

namespace Program_ElementaryOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two numbers
            Console.WriteLine("Enter two numbers like in the example (2, 4)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string by commas to get individual numbers
                string[] numbers = input.Split(',');

                // Check if exactly 2 numbers are provided
                if (numbers.Length == 2)
                {
                    // Try to parse each number
                    if (int.TryParse(numbers[0], out int first) && int.TryParse(numbers[1], out int second))
                    {
                        Console.WriteLine($"Addition: {PerformAddition(first, second)}");
                        Console.WriteLine($"Subtraction: {PerformSubtraction(first, second)}");
                        Console.WriteLine($"Multiplication: {PerformMultiplication(first, second)}");

                        // Check if the second number is not 0 before performing division
                        if (second != 0)
                        {
                            Console.WriteLine($"Division: {PerformDivision(first, second)}");
                        }
                        else
                        {
                            Console.WriteLine("Can't divide by 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        static int PerformAddition(int x, int y)
        {
            return x + y;
        }

        // Method to perform subtraction
        static int PerformSubtraction(int x, int y)
        {
            return x - y;
        }

        // Method to perform multiplication
        static int PerformMultiplication(int x, int y)
        {
            return x * y;
        }

        // Method to perform division
        static double PerformDivision(int x, int y)
        {
            if (y != 0)
            {
                return (double)x / y;
            }
            else
            {
                // Throw an exception if trying to divide by 0
                throw new ArgumentException("Can't divide by 0.");
            }
        }
    }
}
