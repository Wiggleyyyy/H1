using System;

namespace Program_IfYearIsLeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a year
            Console.WriteLine("Enter a year like in example (2016)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Convert the input to an integer
                int year = (int)Convert.ToUInt64(input);

                bool isLeap = CheckIfLeapYear(year);

                Console.WriteLine(isLeap);
            }
        }

        // Method to check if a year is a leap year
        static bool CheckIfLeapYear(int year)
        {
            // Check the leap year conditions
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
