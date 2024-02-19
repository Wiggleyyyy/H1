using System;

namespace Program_SumAndAverage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two numbers
            Console.WriteLine("Enter two numbers like in example (1,2)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string into an array of numbers
                string[] numbers = input.Split(',');

                // Check if the array has exactly two elements
                if (numbers.Length == 2)
                {
                    // Convert the string representations of numbers to integers
                    int first = (int)Convert.ToInt64(numbers[0]);
                    int second = (int)Convert.ToInt64(numbers[1]);

                    string result = SumAndAverage(first, second);
                    Console.WriteLine(result);
                }
            }
        }

        // Method to calculate the sum and average of numbers within a given range
        static string SumAndAverage(int n, int m)
        {
            // Check if n is greater than m and throw an exception if true
            if (n > m)
            {
                throw new ArgumentException("Invalid input: n should be less than or equal to m.");
            }

            int sum = 0;
            int count = 0;

            // Iterate over the numbers from n to m
            for (int i = n; i <= m; i++)
            {
                sum += i;
                count++;
            }

            double average = (double)sum / count;

            return $"Sum: {sum}, Average: {average:F1}";
        }
    }
}
