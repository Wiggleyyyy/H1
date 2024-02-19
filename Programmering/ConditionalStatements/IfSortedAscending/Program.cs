using System;

namespace Program_IfSortedAscending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter numbers
            Console.WriteLine("Enter numbers like in example (1,2,3)");
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

                    bool isSorted = CheckIfSortedAscending(numbers);

                    Console.WriteLine(isSorted);
                }
            }
        }

        // Method to check if an array is sorted in ascending order
        static bool CheckIfSortedAscending(int[] array)
        {
            if (array.Length == 3)
            {
                return array[0] <= array[1] && array[1] <= array[2];
            }
            else
            {
                return false;
            }
        }
    }
}
