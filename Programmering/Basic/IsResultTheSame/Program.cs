using System;
using System.Data; 

namespace Program_IsResultTheSame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter two arithmetic operations
            Console.WriteLine("Enter two arithmetic operations like in the example (2+2, 2*2)");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Split the input string by commas to get individual arithmetic expressions
                string[] arithmeticValues = input.Split(',');

                // Check if exactly 2 arithmetic expressions are provided
                if (arithmeticValues.Length == 2)
                {
                    double firstResult = EvaluateArithmeticExpression(arithmeticValues[0]);
                    double secondResult = EvaluateArithmeticExpression(arithmeticValues[1]);

                    // Check if the results are the same and print the corresponding message
                    if (IsResultSame(firstResult, secondResult))
                    {
                        Console.WriteLine("Results are the same");
                    }
                    else
                    {
                        Console.WriteLine("Results are different");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        // Method to evaluate the result of an arithmetic expression using DataTable.Compute
        static double EvaluateArithmeticExpression(string expression)
        {
            // Create a DataTable to use Compute method for expression evaluation
            DataTable table = new DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty));
        }

        // Method to check if two double values are the same
        static bool IsResultSame(double first, double second)
        {
            return first == second;
        }
    }
}
