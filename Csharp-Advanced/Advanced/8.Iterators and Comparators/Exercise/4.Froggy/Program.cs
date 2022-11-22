using System;
using System.Linq;

namespace _4.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Lake lake = new Lake(input);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
