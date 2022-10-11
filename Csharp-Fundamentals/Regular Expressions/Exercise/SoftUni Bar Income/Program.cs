using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[0-9]+)\|[^|$%.]*?(?<price>[\d]+.?[\d]+)?\$";

            string input = Console.ReadLine();

            double sum = 0;

            while (input != "end of shift")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    string name = Regex.Match(input, pattern).Groups["name"].Value;
                    string product = Regex.Match(input, pattern).Groups["product"].Value;
                    int count = int.Parse(Regex.Match(input, pattern).Groups["count"].Value);
                    double price = double.Parse(Regex.Match(input, pattern).Groups["price"].Value);

                    double priceForCurrProduct = price * count;
                    Console.WriteLine($"{name}: {product} - {priceForCurrProduct:f2}");

                    sum += priceForCurrProduct;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}
