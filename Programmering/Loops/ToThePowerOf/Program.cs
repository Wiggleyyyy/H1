using System;

namespace Program_ToThePowerOf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two numbers
            Console.WriteLine("Enter two numbers like in example (1,2)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string into an array of numbers
                string[] numbers = input.Split(",");

                // Check if there are exactly two elements in the array
                if (numbers.Length == 2)
                {
                    // Try parsing the input numbers
                    if (int.TryParse(numbers[0], out int baseNumber) && int.TryParse(numbers[1], out int exponent))
                    {
                        double result = ToThePowerOf(baseNumber, exponent);

                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter valid integers.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter exactly two numbers.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to calculate the power of a number
        static double ToThePowerOf(int baseNumber, int exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }
    }
}
