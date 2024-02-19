using System;

namespace AddTwoNumbers
{
    internal class AddTwoNumbers
    {
        static void Main(string[] args)
        {
            // Prompt user to enter the first number
            Console.WriteLine("Enter first number");
            int firstNumber = (int)Convert.ToInt64(Console.ReadLine());

            // Prompt user to enter the second number
            Console.WriteLine("Enter second number");
            int secondNumber = (int)Convert.ToInt64(Console.ReadLine());

            // Prompt user to enter the third number
            Console.WriteLine("Enter third number");
            int thirdNumber = (int)Convert.ToInt64(Console.ReadLine());

            // Calculate the result using the Calculate method and store it in a string
            string result = Calculate(firstNumber, secondNumber, thirdNumber).ToString();

            // Check if the result is not null or empty
            if (!String.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
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
