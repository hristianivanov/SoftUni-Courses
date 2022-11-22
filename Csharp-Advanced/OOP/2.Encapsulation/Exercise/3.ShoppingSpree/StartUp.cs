using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] clientsArgs = Console.ReadLine()
                                          .Split(";");

            string[] productArgs = Console.ReadLine()
                                          .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> clients = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                for (int i = 0; i < clientsArgs.Length; i++)
                {
                    string[] currClientArgs = clientsArgs[i].Split("=");

                    Person person = new Person(currClientArgs.First(),
                                               decimal.Parse(currClientArgs.Last())
                                               );

                    clients.Add(person);
                }
                for (int i = 0; i < productArgs.Length; i++)
                {
                    string[] currPrdouctArgs = productArgs[i].Split("=");

                    Product product = new Product(currPrdouctArgs.First(),
                                               decimal.Parse(currPrdouctArgs.Last())
                                               );

                    products.Add(product);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message); return;
            }
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                string product = data[1];

                clients.SingleOrDefault(c => c.Name == name)
                       .Buy(products.SingleOrDefault(p => p.Name == product));
            }

            clients.ForEach(c => Console.WriteLine(c));
        }
    }
}
