namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Exceptions;
    using Interfaces;
    using IO.Interfaces;
    using Models.Animals;
    using Models.Interfaces;
    using Models.Foods;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                try
                {
                    IAnimal animal = GetAnimalType(command);

                    animals.Add(animal);

                    IFood food = GetFoodType();

                    writer.WriteLine(animal.ProduceSound());

                    animal.Eat(food);
                }
                catch (InvalidAnimalTypeException iate)
                {
                    writer.WriteLine(iate.Message);
                }
                catch (InvalidFoodTypeException ifte)
                {
                    writer.WriteLine(ifte.Message);
                }
                catch (FoodNotEatenException fnee)
                {
                    writer.WriteLine(fnee.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            this.PrintAllAnimals();
        }

        private IFood GetFoodType()
        {
            IFood food;
            string[] foodArgs = this.reader.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodArgs[0];
            int foodQty = int.Parse(foodArgs[1]);

            if (foodType == "Vegetable")
                food = new Vegetable(foodQty);
            else if (foodType == "Fruit")
                food = new Fruit(foodQty);
            else if (foodType == "Meat")
                food = new Meat(foodQty);
            else if (foodType == "Seeds")
                food = new Seeds(foodQty);
            else
                throw new InvalidFoodTypeException();
            return food;
        }
        private static IAnimal GetAnimalType(string command)
        {
            IAnimal animal;
            string[] cmdArgs = command
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = cmdArgs[0];
            string name = cmdArgs[1];
            double weight = double.Parse(cmdArgs[2]);
            string fourthArg = cmdArgs[3];

            if (type == "Owl")
                animal = new Owl(name, weight, double.Parse(fourthArg));
            else if (type == "Hen")
                animal = new Hen(name, weight, double.Parse(fourthArg));
            else if (type == "Mouse")
                animal = new Mouse(name, weight, fourthArg);
            else if (type == "Dog")
                animal = new Dog(name, weight, fourthArg);
            else if (type == "Cat")
                animal = new Cat(name, weight, fourthArg, cmdArgs[4]);
            else if (type == "Tiger")
                animal = new Tiger(name, weight, fourthArg, cmdArgs[4]);
            else
                throw new InvalidAnimalTypeException();
            return animal;
        }
        private void PrintAllAnimals()
        {
            foreach (IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal);
            }
        }
    }
}
