using System;

namespace Multiplication_Sign
{
    internal class Program
    {
        private static bool IsNegative(string num)
        {
            if (num[0] == '-') return true;
            return false;
        }

        static void Main(string[] args)
        {
            var num1 = Console.ReadLine();
            var num2 = Console.ReadLine();
            var num3 = Console.ReadLine();

            int counterNegative = 0;

            if (int.Parse(num1) == 0 || int.Parse(num2) == 0 || int.Parse(num3) == 0)
            {
                Console.WriteLine("zero"); return;
            }

            if (IsNegative(num1))
            {
                counterNegative++;
            }
            if (IsNegative(num2))
            {
                counterNegative++;
            }
            if (IsNegative(num3))
            {
                counterNegative++;
            }

            Console.WriteLine(counterNegative % 2 == 0 ? "positive" : "negative");


        }
    }
}
