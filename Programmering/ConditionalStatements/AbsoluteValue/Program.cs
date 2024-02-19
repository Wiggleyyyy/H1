using System;

namespace Program_AbsoluteValue
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

                int absoluteOfNumber = GetAbsoluteValue(number);

                Console.WriteLine(absoluteOfNumber.ToString());
            }
        }

        // Method to get the absolute value of a number using Math.Abs
        static int GetAbsoluteValue(int number)
        {
            return Math.Abs(number);
        }
    }
}
