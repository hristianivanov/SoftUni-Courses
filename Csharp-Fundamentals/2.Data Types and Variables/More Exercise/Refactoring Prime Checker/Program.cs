using System;

namespace Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int num = 2; num <= n; num++)
            {
                bool isPrime = true;
                for (int divisible = 2; divisible < num; divisible++)
                {
                    if (num % divisible == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{num} -> {isPrime.ToString().ToLower()}");
            }

        }
    }
}
