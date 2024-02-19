namespace AddTwoNumbers
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 numbers like in the example (2, 4, 5)");
            string input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input) )
            {
                string[] numbers = input.Split(',');

                if (numbers.Length > 0 )
                {
                    if (int.TryParse(numbers[0], out int first) && int.TryParse(numbers[1], out int second) && int.TryParse(numbers[2], out int third))
                    {
                        string result = Calculate(first, second, third).ToString();

                        if (!String.IsNullOrEmpty(result) )
                        {
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
        }

        static int Calculate(int first, int second, int third)
        {
            int result = (first + second) * third;

            return result;
        }
    }
}