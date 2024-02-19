using System;

namespace Program_TheBiggestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter numbers
            Console.WriteLine("Enter numbers like in example (1,2,3,4,5 ...)");
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

                    int highestNumber = findHighestNumber(numbers);

                    Console.WriteLine(highestNumber.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        // Method to find the highest number in an array of integers
        static int findHighestNumber(int[] numbers)
        {
            int maxNumber = numbers[0];

            // Iterate over the array to find the maximum number
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }
    }
}
