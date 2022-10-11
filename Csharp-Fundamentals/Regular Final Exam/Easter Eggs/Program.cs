using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string pattern = @"[@#]+(?<color>[a-z]{3,})[@#]+[^\dA-Za-z]*[/]+(?<ammount>[\d]+)[/]+";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"You found {match.Groups["ammount"]} {match.Groups["color"]} eggs!");
            }
        }
    }
}
