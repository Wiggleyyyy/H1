using System;

namespace Program_HowManyOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a string and a substring
            Console.WriteLine("Enter string and substring like in example (hello, h)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input by comma to separate the string and the substring
                string[] inputStrings = input.Split(",");

                // Check if the input contains both a string and a substring
                if (inputStrings.Length == 2)
                {
                    string first = inputStrings[0];
                    string second = inputStrings[1];

                    int numberOfOccurrences = countOccurrences(first, second);

                    Console.WriteLine(numberOfOccurrences.ToString());
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

        // Method to count the occurrences of a substring within a string
        static int countOccurrences(string first, string second)
        {
            int counter = 0;

            // Iterate through each character in the first string
            foreach (char c in first)
            {
                string letter = c.ToString();
                if (letter == second)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
