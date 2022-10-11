using System;

namespace _1._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (strings) => Console.WriteLine(string.Join(Environment.NewLine, strings));
            string[] input = Console.ReadLine().Split();
            print(input);
        }
    }
}
