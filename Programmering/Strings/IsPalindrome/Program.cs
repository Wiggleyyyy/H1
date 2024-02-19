using System;

namespace IsPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a word
            Console.WriteLine("Enter a word like in example (eye)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                bool isPalindrome = checkIfPalindrome(input);

                Console.WriteLine(isPalindrome);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to check if a string is a palindrome
        static bool checkIfPalindrome(string input)
        {
            input = input.ToLower();

            int length = input.Length;

            // Loop through the characters of the string, comparing characters from both ends
            for (int i = 0; i < length / 2; i++)
            {
                // If characters at symmetric positions are not equal, it's not a palindrome
                if (input[i] != input[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
