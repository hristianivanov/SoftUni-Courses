using System;
using System.Linq;
using System.Collections.Generic;

namespace Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string,List<string>> keyValuePairs = new Dictionary<string,List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word].Add(synonym);
                }
                else
                {
                    keyValuePairs.Add(word, new List<string>() { synonym });
                }
            }

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ",item.Value)}");
            }
        }
    }
}
