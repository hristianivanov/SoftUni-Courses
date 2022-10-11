using System;

namespace Tribonacci_Sequence
{
    internal class Program
    {
        private static int Tribonacci(int num)
        {
            if (num == 0) return 0;
            if (num == 1) return 1;
            if (num == 2) return 1;
            return (Tribonacci(num - 1) + Tribonacci(num - 2) + Tribonacci(num - 3));
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{Tribonacci(i)} ");
            }
        }
    }
}
