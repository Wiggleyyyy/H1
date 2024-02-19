using System;

namespace Program_CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter the temperature in Celsius
            Console.WriteLine("Enter Celsius");
            int celsius = (int)Convert.ToInt64(Console.ReadLine());

            string result = ConvertToFahrenheit(celsius).ToString();

            // Check if the result is not null or empty
            if (!String.IsNullOrEmpty(result))
            {
                Console.WriteLine($"{celsius} Celsius is equal to {result} Fahrenheit");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        // Method to convert Celsius to Fahrenheit
        static double ConvertToFahrenheit(int celsius)
        {
            //Fahrenheit = (Celsius * 1.8) + 32

            double fahrenheit = (celsius * 1.8) + 32;

            return fahrenheit;
        }
    }
}
