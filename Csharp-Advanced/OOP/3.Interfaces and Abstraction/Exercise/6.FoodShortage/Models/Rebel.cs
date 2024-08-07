﻿
namespace FoodShortage.Models
{
    using Interfaces;
    public class Rebel : IBuyer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public void BuyFood() => Food += 5;

    }
}
