using System;
using System.Text;

namespace Program_CompressString
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
                string compressedString = CompressString(input);
                Console.WriteLine(compressedString);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to compress a string
        static string CompressString(string input)
        {
            StringBuilder compressed = new StringBuilder();

            char currentChar = input[0];
            int count = 1;

            // Iterate through the string starting from the second character
            for (int i = 1; i < input.Length; i++)
            {
                // If current character is same as previous character, increment count
                if (input[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    // If current character is different, append compressed version of previous character and its count
                    compressed.Append(currentChar);
                    compressed.Append(count);

                    count = 1;
                    currentChar = input[i];
                }
            }

            // Append the last character and its count
            compressed.Append(currentChar);
            compressed.Append(count);

            return compressed.ToString();
        }
    }
}
