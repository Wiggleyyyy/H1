using System;

namespace Program_SortCharactersDecending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a string
            Console.WriteLine("Enter a string");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                string result = SortCharactersDescending(input);

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to sort characters in descending order and return the result as a string
        static string SortCharactersDescending(string input)
        {
            char[] chars = input.ToCharArray();

            Array.Sort(chars);
            Array.Reverse(chars);

            return new string(chars);
        }
    }
}
