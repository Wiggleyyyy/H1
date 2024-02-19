using System;

namespace Program_DrawTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter the height of the triangle
            Console.WriteLine("Enter height of triangle");
            string input = Console.ReadLine();

            // Check if the input is not null or empty and is a valid integer greater than 0
            if (!String.IsNullOrEmpty(input) && int.TryParse(input, out int height) && height > 0)
            {
                DrawTriangle(height);
            }
            else
            {
                Console.WriteLine("Invalid or no height entered, defaulting to 10");
                height = 10;

                DrawTriangle(height);
            }
        }

        // Method to draw a centered triangle with the specified height
        static void DrawTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                // Print leading spaces to center the triangle
                for (int j = 0; j < height - i - 1; j++)
                {
                    Console.Write(" ");
                }

                // Print '*' characters to form the triangle
                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
