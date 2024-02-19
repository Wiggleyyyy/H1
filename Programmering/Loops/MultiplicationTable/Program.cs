using System;

namespace Program_MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two numbers
            Console.WriteLine("Enter 2 numbers to make a table like in example (10,10)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input into an array of strings using ',' as the delimiter
                string[] numbers = input.Split(',');

                // Check if the array has exactly two elements
                if (numbers.Length == 2)
                {
                    // Convert the strings to integers for rows and columns
                    int rows = (int)Convert.ToInt64(numbers[0]);
                    int columns = (int)Convert.ToInt64(numbers[1]);

                    drawTable(rows, columns);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
            }
        }

        // Method to draw the multiplication table
        static void drawTable(int rows, int columns)
        {
            // Nested loops to iterate through rows and columns
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    // Print the product of i and j followed by a tab
                    Console.Write($"{i * j}\t");
                }
                // Move to the next line after completing a row
                Console.WriteLine();
            }
        }
    }
}
