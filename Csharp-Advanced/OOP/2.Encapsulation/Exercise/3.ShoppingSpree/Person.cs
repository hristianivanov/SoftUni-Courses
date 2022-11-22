using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag { get => bag.AsReadOnly(); }
        public void Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                Console.WriteLine($"{Name} bought {product}");
                Money -= product.Cost;
                bag.Add(product);
            }
            else
                Console.WriteLine($"{Name} can't afford {product}");
        }

        public override string ToString()
        {
            if (Bag.Any())
                return $"{Name} - {string.Join(", ", Bag)}";
            else
                return $"{Name} - Nothing bought ";
        }
    }
}

