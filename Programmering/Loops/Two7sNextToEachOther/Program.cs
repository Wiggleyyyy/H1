using System;

namespace Program_Two7sNextToEachOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter numbers like in the example
            Console.WriteLine("Enter numbers like in example (1,7,7,3 ...)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string into an array of numbers
                string[] numbersTemp = input.Split(',');

                // Check if there are more than one element in the array
                if (numbersTemp.Length > 1)
                {
                    // Try parsing the input numbers
                    if (int.TryParse(numbersTemp[0], out int parsedNumber))
                    {
                        int result = Two7sNextToEachOther(numbersTemp);

                        Console.WriteLine(result.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter valid integers.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter at least two numbers.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // Method to count the number of occurrences where two 7s are next to each other
        static int Two7sNextToEachOther(string[] array)
        {
            int count = 0;

            // Loop through the array and check for two 7s next to each other
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (int.TryParse(array[i], out int currentNumber) && int.TryParse(array[i + 1], out int nextNumber))
                {
                    if (currentNumber == 7 && nextNumber == 7)
                    {
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    return 0;
                }
            }

            return count;
        }
    }
}
