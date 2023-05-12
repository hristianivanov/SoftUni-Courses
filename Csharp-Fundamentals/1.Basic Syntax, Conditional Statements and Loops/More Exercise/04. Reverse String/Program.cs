using System;
using System.Linq;

namespace _04_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                string.Join("", Console.ReadLine()
                .ToCharArray()
                .Reverse()
                ));
        }
    }
}
