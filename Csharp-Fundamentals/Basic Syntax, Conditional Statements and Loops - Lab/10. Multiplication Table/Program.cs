using System;

namespace _10._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int times = 1; times <= 10; times++)
            {
                Console.WriteLine($"{num} X {times} = {num * times}");
            }
        }
    }
}
