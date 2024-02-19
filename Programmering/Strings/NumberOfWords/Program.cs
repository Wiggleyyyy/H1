using System;

namespace Program_NumberOfWords
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
                int wordCount = numberOfWords(input);

                Console.WriteLine(wordCount);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to count the number of words in a string
        static int numberOfWords(string input)
        {
            // Split the input string by whitespace
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words.Length;
        }
    }
}
