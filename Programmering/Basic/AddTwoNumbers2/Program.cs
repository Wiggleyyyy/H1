using System;

namespace AddTwoNumbers
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter 3 numbers
            Console.WriteLine("Enter 3 numbers like in the example (2, 4, 5)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string by commas to get individual numbers
                string[] numbers = input.Split(',');

                // Check if exactly 3 numbers are provided
                if (numbers.Length == 3)
                {
                    // Try to parse each number
                    if (int.TryParse(numbers[0], out int first) && int.TryParse(numbers[1], out int second) && int.TryParse(numbers[2], out int third))
                    {
                        string result = Calculate(first, second, third).ToString();

                        // Check if the result is not null or empty
                        if (!String.IsNullOrEmpty(result))
                        {
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        // Method to calculate the result by adding the first and second numbers and then multiplying by the third number
        static int Calculate(int first, int second, int third)
        {
            int result = (first + second) * third;

            return result;
        }
    }
}
