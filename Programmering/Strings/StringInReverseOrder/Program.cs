using System;
using System.Text;
using Program_StringInReverseOrder;

namespace Program_StringInReverseOrder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Prompt the user to enter a string
            Console.WriteLine("Enter a string");
            string input = Console.ReadLine();
            
            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                string reversedString = StringInReverseOrder(input);

                Console.WriteLine(reversedString);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to reverse a string
        public static string StringInReverseOrder(string input)
        {
            StringBuilder reversedBuilder = new StringBuilder();

            // Iterate through the characters of the input string in reverse order
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedBuilder.Append(input[i]);
            }

            return reversedBuilder.ToString();
        }
    }
}
