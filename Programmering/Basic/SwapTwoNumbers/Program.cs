using System;

namespace Program_ModuloOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter three numbers
            Console.WriteLine("Enter three numbers like in the example (2, 2, 2)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string by commas to get individual numbers
                string[] numbers = input.Split(',');

                // Check if exactly 3 numbers are provided
                if (numbers.Length == 3)
                {
                    // Try to parse each number
                    if (int.TryParse(numbers[0], out int first) && int.TryParse(numbers[1], out int second) && int.TryParse(numbers[2], out int third))
                    {
                        string result = Calculate(first, second, third).ToString();

                        Console.WriteLine(result);
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

        // Method to perform modulo operations
        static int Calculate(int first, int second, int third)
        {
            int result = (first % second) / third;

            return result;
        }
    }
}
