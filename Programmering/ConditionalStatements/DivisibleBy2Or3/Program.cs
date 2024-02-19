using System;

namespace Program_DivisibleBy2Or3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two numbers
            Console.WriteLine("Enter two numbers like in example (2, 2)");
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
                        string result = DivisibleBy2Or3(first, second).ToString();

                        // Check if the result is not null or empty
                        if (!String.IsNullOrEmpty(result))
                        {
                            Console.Write(result);
                        }
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

        // Method to determine if both numbers are divisible by 2 or 3, and return the appropriate result
        static int DivisibleBy2Or3(int first, int second)
        {
            // Check if both numbers are divisible by 2 or 3
            if ((first % 2 == 0 || first % 3 == 0) && (second % 2 == 0 || second % 3 == 0))
            {
                return first * second;
            }
            else
            {
                return first + second;
            }
        }
    }
}
