using System;

namespace Top_Number
{
    internal class Program
    {
        private static bool IsDivisibleBy8(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                int last = num % 10;
                sum += last;
                num /= 10;
            }
            if (sum % 8 == 0)
            {
                return true;
            }
            return false;
        }

        private static bool WhetherConsistOddDigit(int num)
        {
            while (num != 0)
            {
                int last = num % 10;
                if (last % 2 != 0)
                {
                    return true;
                }
                num /= 10;
            }
            return false;
        }
        static void Main(string[] args)
        {
            
            int end = int.Parse(Console.ReadLine());

            for (int i = 1; i < end; i++)
            {
                if (IsDivisibleBy8(i))
                {
                    if (WhetherConsistOddDigit(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
