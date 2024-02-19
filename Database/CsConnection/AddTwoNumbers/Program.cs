namespace AddTwoNumbers
{
    internal class AddTwoNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            int firstNumber = (int)Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter second number");
            int secondNumber = (int)Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter third number");
            int thirdNumber = (int)Convert.ToInt64(Console.ReadLine());

            string result = Calculate(firstNumber, secondNumber, thirdNumber).ToString();

            if (!String.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }

        static int Calculate(int first, int second, int third)
        {
            int result = (first + second) * third;

            return result;
        }
    }
}