using System;

namespace Program_IfNumberIsEven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a number
            Console.WriteLine("Enter a number");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Convert the input to an integer
                int number = (int)Convert.ToInt64(input);

                bool isEven = CheckIfEven(number);

                Console.WriteLine(isEven);
            }
        }

        // Method to check if a number is even
        static bool CheckIfEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
