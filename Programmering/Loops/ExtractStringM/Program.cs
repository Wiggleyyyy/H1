using System;

namespace Program_ExtractStringM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a string
            Console.WriteLine("Enter a string like in the example (wagd##output##asda)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                string subString = ExtractString(input);

                // Check if the extracted substring is not null or empty
                if (!String.IsNullOrEmpty(subString))
                {
                    Console.WriteLine(subString);
                }
                else
                {
                    Console.WriteLine("Empty");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to extract a substring between two double hash signs
        static string ExtractString(string input)
        {
            int firstHashIndex = input.IndexOf("##");
            int secondHashIndex = input.IndexOf("##", firstHashIndex + 2);

            // Check if both hash signs were found in the correct order
            if (firstHashIndex != -1 && secondHashIndex != -1 && secondHashIndex > firstHashIndex)
            {
                // Extract the substring between the two hash signs
                return input.Substring(firstHashIndex + 2, secondHashIndex - firstHashIndex - 2);
            }

            return String.Empty;
        }
    }
}
