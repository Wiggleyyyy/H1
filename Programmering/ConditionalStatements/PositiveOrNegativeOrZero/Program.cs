using System;

namespace Program_PositiveOrNegativeOrZero
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
                // Convert the input to a double
                double number = (double)Convert.ToDouble(input);

                CheckIfIsPositiveOrNegativeOrZero(number);
            }
        }

        // Method to check if a number is positive, negative, or zero
        static void CheckIfIsPositiveOrNegativeOrZero(double input)
        {
            // Check if the number is positive
            if (input > 0)
            {
                Console.WriteLine("Positive");
            }
            // Check if the number is negative
            else if (input < 0)
            {
                Console.WriteLine("Negative");
            }
            // If neither positive nor negative, it must be zero
            else
            {
                Console.WriteLine("Zero");
            }
        }
    }
}
