using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < input.First(); i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < input.Last(); i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            first.IntersectWith(second);
            Console.WriteLine(string.Join(" ",first));
        }
    }
}
