using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] sequence = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var occurences = new Dictionary<double, int>();
            foreach (var num in sequence)
            {
                if (!occurences.ContainsKey(num))
                {
                    occurences.Add(num, 0);
                }
                occurences[num]++;
            }
            foreach (var occurence in occurences)
            {
                Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
            }
        }
    }
}
