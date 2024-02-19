using System;

namespace Program_FullSequenceOfLettersM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two letters
            Console.WriteLine("Enter two letters like in example (ad)");
            string input = Console.ReadLine().ToLower();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                string result = FullSequenceOfLetters(input);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to generate the full sequence of letters between two given letters
        static string FullSequenceOfLetters(string input)
        {
            // Check if the input has a length of 2, the first letter is less than the second one, and both are letters
            if (input.Length == 2 && input[0] < input[1] && char.IsLetter(input[0]) && char.IsLetter(input[1]))
            {
                char startChar = input[0];
                char endChar = input[1];

                // Initialize an empty string to store the result
                string result = "";

                // Loop through the characters from startChar to endChar (inclusive)
                for (char currentChar = startChar; currentChar <= endChar; currentChar++)
                {
                    // Append the current character to the result string
                    result += currentChar;
                }

                return result;
            }

            return string.Empty;
        }
    }
}
