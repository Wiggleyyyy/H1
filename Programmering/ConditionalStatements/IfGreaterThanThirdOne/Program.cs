using System;

namespace Program_IfGreaterThanThirdOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter three numbers
            Console.WriteLine("Enter three numbers like in example (1, 2, 3)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string by commas to get individual numbers
                string[] numbersTemp = input.Split(",");

                // Check if exactly 3 numbers are provided
                if (numbersTemp.Length == 3)
                {
                    // Create an array to store parsed numbers
                    int[] numbers = new int[numbersTemp.Length];

                    // Iterate through each number in the input string
                    for (int i = 0; i < numbersTemp.Length; i++)
                    {
                        if (int.TryParse(numbersTemp[i], out int parsedNumber))
                        {
                            numbers[i] = parsedNumber;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                    }

                    bool isGreater = CheckIfGreater(numbers[0], numbers[1], numbers[2]);

                    Console.WriteLine(isGreater);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        // Method to check if the product of the first and second numbers or the sum is greater than the third number
        static bool CheckIfGreater(int first, int second, int third)
        {
            int multipliedValue = first * second;
            int addedValue = first + second;

            // Check if either the product or the sum is greater than the third number
            if (multipliedValue > third || addedValue > third)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
