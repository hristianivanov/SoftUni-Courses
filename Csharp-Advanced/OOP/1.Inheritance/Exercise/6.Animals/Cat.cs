using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound() => "Meow meow";
    }
}
