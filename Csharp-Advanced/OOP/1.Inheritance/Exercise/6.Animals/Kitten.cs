using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age)
        {
        }

        public override string Gender { get => "Female"; }
        public override string ProduceSound() => "Meow";
    }
}
