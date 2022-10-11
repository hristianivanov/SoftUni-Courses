using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(":");

            Dictionary<string,List<string>> keyValuePairs = new Dictionary<string,List<string>>();  

            while (input[0]!="end")
            {

                if (keyValuePairs.ContainsKey(input[0].Trim()))
                {
                    keyValuePairs[input[0].Trim()].Add(input[1].Trim());
                }
                else
                {
                    keyValuePairs.Add(input[0].Trim(),
                        new List<string>() { input[1].Trim() }
                        );
                }

                input = Console.ReadLine().Split(":");
            }

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                item.Value.ForEach(person => Console.WriteLine($"-- {person}"));
            }

        }
    }
}
