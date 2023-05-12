using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int,int> keyValuePairs = new SortedDictionary<int,int>();

            var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (var item in input)
            {
                if (keyValuePairs.ContainsKey(item))
                {
                    keyValuePairs[item]++;
                }
                else
                {
                    keyValuePairs.Add(item, 1);
                }
            }

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
