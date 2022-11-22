using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private const int BASE_CALORIES = 2;
        private Dictionary<string, double> modifier;
        private double weight;
        private string type;

        public Topping( string type,double weight)
        {
            modifier = new Dictionary<string, double>();
            SetModifiers();
            this.Type = type;
            this.Weight = weight;
        }
        public double CaloriesPerGram => modifier[this.Type.ToLower()];
        public string Type 
        { 
            get => type;
            private set 
            {
                if (!modifier.ContainsKey(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }
        public double Weight 
        { 
            get => weight;
            private set
            {
                if (!WeightRange(value))
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                weight = value;
            }
        }

        private void SetModifiers()
        {
            this.modifier.Add("meat", 1.2);
            this.modifier.Add("veggies", 0.8);
            this.modifier.Add("cheese", 1.1);
            this.modifier.Add("sauce", 0.9);
        }
        private bool WeightRange(double value) => value >= 1 && value <= 50;
        public double GetCalories() => BASE_CALORIES * Weight * CaloriesPerGram;
    }
}
