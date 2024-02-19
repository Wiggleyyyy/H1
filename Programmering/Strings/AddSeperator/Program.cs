using System;
using System.Text; // Import the System.Text namespace for StringBuilder

namespace Program_AddSeperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter input
            Console.WriteLine("Enter some letters and a separator like in example (abc, -)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input by comma to separate the string and separator
                string[] inputStrings = input.Split(",");

                string result = AddSeperator(inputStrings[0], inputStrings[1]);

                Console.WriteLine(result);
            }
        }

        // Method to add separator between characters in a string
        static string AddSeperator(string input, string separator)
        {
            // Check if the input string is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                StringBuilder resultBuilder = new StringBuilder();

                // Append the first character of the input string
                resultBuilder.Append(input[0]);

                // Loop through the characters, starting from the second one
                for (int i = 1; i < input.Length; i++)
                {
                    resultBuilder.Append(separator);
                    resultBuilder.Append(input[i]);
                }

                return resultBuilder.ToString();
            }
            else
            {
                return "Invalid input";
            }
        }
    }
}
