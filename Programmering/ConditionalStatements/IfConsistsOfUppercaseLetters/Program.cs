using System;

namespace Program_IfConsistsOfUppercaseLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter three letters
            Console.WriteLine("Enter three letters like in example (abc)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                bool containsUppercase = IfConsistsOfUppercaseLetters(input);

                Console.WriteLine(containsUppercase);
            }
        }

        // Method to check if the input string consists of three uppercase letters
        static bool IfConsistsOfUppercaseLetters(string input)
        {
            if (input.Length == 3)
            {
                // Iterate through each character in the input string
                foreach (char c in input)
                {
                    // Check if the character is not an uppercase letter
                    if (!Char.IsUpper(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
