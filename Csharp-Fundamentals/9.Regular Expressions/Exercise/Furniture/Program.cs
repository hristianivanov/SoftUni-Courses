using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<item>[A-Z]+[a-z]*)<<(?<price>[\d]+[.[\d]+]*)!(?<quantity>[\d]+)";

            string input = Console.ReadLine();
            
            Console.WriteLine("Bought furniture:");

            double sum = 0.0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    sum += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);

                    Console.WriteLine(match.Groups["item"]);
                }
                     input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {sum:f2}");

           
        }
    }
}
