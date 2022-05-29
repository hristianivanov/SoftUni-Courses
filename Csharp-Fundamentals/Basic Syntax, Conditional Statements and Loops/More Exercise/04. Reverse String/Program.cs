using System;
using System.Linq;

namespace _04_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray().Reverse();
            Console.WriteLine(string.Join("",input));
        }
    }
}
