using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participants = Console.ReadLine().Split(", ").ToList();

            Dictionary<string, int> pair = new Dictionary<string, int>();

            var letters = @"(?<letters>[A-Za-z])";
            var digits = @"(?<digits>[\d])";

            var input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection matchLetters = Regex.Matches(input, letters);

                string name = string.Empty;

                foreach (Match item in matchLetters)
                {
                    name += item;
                }

                MatchCollection matchDigits = Regex.Matches(input, digits);

                int distance = 0;

                foreach (Match item in matchDigits)
                {
                    distance += int.Parse(item.Value);
                }

                if (pair.ContainsKey(name))
                {
                    pair[name] += distance;
                }
                else
                {
                    if (participants.Contains(name))
                    {
                        pair.Add(name, distance);
                    }
                }

                input = Console.ReadLine();
            }

            var output = pair.OrderByDescending(x => x.Value).Take(3).ToList();
            Console.WriteLine($"1st place: {output[0].Key}");
            Console.WriteLine($"2nd place: {output[1].Key}");
            Console.WriteLine($"3rd place: {output[2].Key}");


        }
    }
}
