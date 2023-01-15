using System;
using System.Collections.Generic;

namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atlas = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!atlas.ContainsKey(continent))
                {
                    atlas.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!atlas[continent].ContainsKey(country))
                {
                    atlas[continent].Add(country, new List<string>());
                }
                atlas[continent][country].Add(city);
            }

            foreach (var continent in atlas)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");
                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
