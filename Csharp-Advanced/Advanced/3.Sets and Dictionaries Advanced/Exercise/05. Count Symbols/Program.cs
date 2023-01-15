using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> kvp = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (kvp.ContainsKey(input[i]))
                {
                    kvp[input[i]]++; continue;
                }
                kvp.Add(input[i], 1);
            }

            foreach (KeyValuePair<char,int> item in kvp)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
