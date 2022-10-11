using System;
using System.Linq;
using System.Collections.Generic;

namespace Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split("->",StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> pair = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string companyName = input[0];
                string employersID = input[1];

                if (!pair.ContainsKey(companyName))
                {
                    pair.Add(companyName, new List<string>());
                }
                if (!pair[companyName].Contains(employersID))
                {
                    pair[companyName].Add(employersID);
                }

                input = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in pair)
            {
                Console.WriteLine($"{item.Key}");
                item.Value.Distinct().ToList().ForEach(person => Console.WriteLine($"--{person}"));
            }

        }
    }
}
