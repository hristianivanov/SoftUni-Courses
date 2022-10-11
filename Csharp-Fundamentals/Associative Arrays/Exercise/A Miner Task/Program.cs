using System;
using System.Linq;
using System.Collections.Generic;

namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
             var resource = Console.ReadLine();

            Dictionary<string, int> pair = new Dictionary<string, int>();   

            while (resource != "stop")
            {
                var quantity = int.Parse(Console.ReadLine());

                if (pair.ContainsKey(resource))
                {
                    pair[resource]+=quantity;
                }
                else
                {
                    pair.Add(resource, quantity);
                }

                resource = Console.ReadLine();

            }
            foreach (var item in pair)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
