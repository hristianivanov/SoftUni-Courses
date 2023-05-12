using System;

namespace _06._Strong_number
{
    internal class Program
    {
        public static int Fact(int num)
        {
            if (num == 0)
                return 1;
            else
                return Fact(num - 1) * num;
        }

        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int input = int.Parse(Console.ReadLine());
                var number = input;
                int sum = 0;
                int i = 0;

                while (input > 0)
                {
                    int cur = input % 10;
                    sum += Fact(cur);
                    input /= 10;
                }

                Console.WriteLine(sum == number ? "yes" : "no");
            }
        }
    }
}