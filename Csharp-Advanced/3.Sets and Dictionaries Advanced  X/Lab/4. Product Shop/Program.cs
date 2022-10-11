using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productInfo = new SortedDictionary<string, Dictionary<string, double>>();
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ");

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!productInfo.ContainsKey(shop))
                {
                    productInfo.Add(shop, new Dictionary<string, double>());
                }
                productInfo[shop].Add(product, price);
            }

            foreach (var shop in productInfo)
            {
                Console.WriteLine($"{shop.Key}->");
                Console.WriteLine(string.Join(Environment.NewLine, shop.Value.Select(x => $"Product: {x.Key}, Price: {x.Value}")));
            }
        }
    }
}
