using System;

namespace Program_TheCubeOf
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
                // Calculate the cube of the entered number and store the result as a string
                string result = CubeOf((int)Convert.ToInt64(input)).ToString();

                // Check if the result is not null or empty
                if (!String.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
        }

        // Method to calculate the cube of a number using Math.Pow
        static double CubeOf(int number)
        {
            return Math.Pow(number, 3);
        }
    }
}
