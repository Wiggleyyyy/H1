using System;
using System.Collections.Generic;

namespace Program_SieveOfEratosthenes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a number
            Console.WriteLine("Enter a number");
            string input = Console.ReadLine();

            // Check if the input is not null or empty
            if (!String.IsNullOrEmpty(input))
            {
                // Convert the input string to an integer
                int number = (int)Convert.ToInt64(input);

                List<int> primes = SieveOfEratosthenes(number);

                Console.WriteLine($"{number}: [{String.Join(", ", primes)}]");
            }
        }

        // Sieve of Eratosthenes algorithm to find prime numbers
        static List<int> SieveOfEratosthenes(int n)
        {
            // Check if the input is less than or equal to 2
            if (n <= 2)
            {
                Console.WriteLine("Invalid input");
                return new List<int>();
            }

            // Initialize a list to store prime numbers
            List<int> primes = new List<int>();
            // Initialize a boolean array to mark numbers as prime or not
            bool[] isPrime = new bool[n + 1];

            // Mark all numbers from 2 to n as true (considered as prime initially)
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            // Iterate over numbers starting from 2
            for (int p = 2; p * p <= n; p++)
            {
                // If p is marked as prime
                if (isPrime[p])
                {
                    // Mark multiples of p as not prime
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            // Collect prime numbers into the list
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
