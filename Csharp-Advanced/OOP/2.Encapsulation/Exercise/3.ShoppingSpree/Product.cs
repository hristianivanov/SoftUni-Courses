﻿using System;

namespace _3.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Cost = price;
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
        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value < 0m)
                    throw new ArgumentException("Money cannot be negative");
                cost = value;
            }
        }

        public override string ToString() => Name;
    }
}
