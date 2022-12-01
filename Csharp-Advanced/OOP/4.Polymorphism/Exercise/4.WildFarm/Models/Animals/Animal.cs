namespace WildFarm.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Exceptions;
    using Interfaces;
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!PreferredFoods.Any(pf => pf.Name == food.GetType().Name))
            {
                throw new FoodNotEatenException(string.Format(
                    ExceptionMessages.FoodNotEatenExceptionMessage,this.GetType().Name, food.GetType().Name)
                    );
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
