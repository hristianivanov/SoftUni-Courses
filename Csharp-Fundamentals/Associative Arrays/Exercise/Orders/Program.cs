using System;
using System.Linq;
using System.Collections.Generic;

namespace Orders
{
    internal class Program
    {
        public class PriceAndQuantity
        {
            public PriceAndQuantity(double price, int quantity)
            {
                Price = price;
                Quantity = quantity;
            }

            public double Price { get; set; }
            public int Quantity { get; set; }

            public double Sum()
            {
                return Price * Quantity;
            }
        }
        static void Main(string[] args)
        {
          
           var input = Console.ReadLine().Split();

            Dictionary<string, PriceAndQuantity> product = new Dictionary<string, PriceAndQuantity>();

            while (input[0] !="buy")
            {
                if (product.ContainsKey(input[0]))
                {
                    product[input[0]].Price = double.Parse(input[1]);
                    product[input[0]].Quantity += int.Parse(input[2]);
                }
                else
                {
                    product.Add(input[0], new PriceAndQuantity(double.Parse(input[1]), int.Parse(input[2]))); 
                }

                input= Console.ReadLine().Split();
            }

            foreach (var item in product)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Sum():f2}");
            }
        }
    }
}
