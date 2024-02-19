using System;

namespace Program_ThreeIncreasingAdjacent
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
                // Split the input string into an array of numbers
                string[] numbersTemp = input.Split(",");

                // Check if there are more than one element in the array
                if (numbersTemp.Length > 1)
                {
                    // Create an array to store parsed integers
                    int[] numbers = new int[numbersTemp.Length];

                    // Parse each element of the array and store it in the 'numbers' array
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

                    bool result = checkIfThreeIncreasingAdjacent(numbers);
                    Console.WriteLine(result);
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

        // Method to check if there are three increasing adjacent numbers in an array
        static bool checkIfThreeIncreasingAdjacent(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                // Check if the current, next, and the one after next numbers are in increasing order
                if (numbers[i + 1] == numbers[i] + 1 && numbers[i + 2] == numbers[i + 1] + 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
