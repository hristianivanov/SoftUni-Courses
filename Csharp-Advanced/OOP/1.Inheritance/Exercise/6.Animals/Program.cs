using _6.Animals;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] data = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                try
                {
                    switch (input)
                    {
                        case "Dog": animals.Add(new Dog(name, age, gender)); break;
                        case "Cat": animals.Add(new Cat(name, age, gender)); break;
                        case "Frog": animals.Add(new Frog(name, age, gender)); break;
                        case "Kittens": animals.Add(new Kitten(name, age)); break;
                        case "Tomcat": animals.Add(new Tomcat(name, age)); break;
                    }
                }
                catch (ArgumentException exception) { Console.WriteLine(exception.Message); }
            }

            animals.ForEach(animal => Console.WriteLine(animal));
        }
    }
}
