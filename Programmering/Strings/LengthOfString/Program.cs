using System;

namespace LengthOfString
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
                int length = getLength(input);

                Console.WriteLine(length.ToString());
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to calculate the length of a string
        static int getLength(string input)
        {
            int length = 0;

            // Iterate through the characters of the input string
            foreach (char c in input)
            {
                // Check if the character is the null terminator ('\0') which marks the end of the string
                if (c == '\0')
                {
                    break;
                }
                length++;
            }

            return length;
        }
    }
}
