using System;
using System.Text.RegularExpressions;

namespace Program_RevertWordsOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter some words
            Console.WriteLine("Enter some words like in example (hello world)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                string result = RevertWordsOrder(input);

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to revert the order of words in a string
        static string RevertWordsOrder(string input)
        {
            // Split the input string by whitespace or punctuation using regular expression
            string[] words = Regex.Split(input, @"(\s+|[.,!?])");

            Array.Reverse(words);

            return string.Join("", words);
        }
    }
}
