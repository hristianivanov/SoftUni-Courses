using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const int BASE_CALORIES = 2;
        private Dictionary<string, double> flourType;
        private Dictionary<string,double> bakingTechnique;

        private double weight;
        private string type;
        private string technique;

        public Dough(string type, string technique, double weight)
        {
            this.flourType = new Dictionary<string, double>();
            this.bakingTechnique = new Dictionary<string, double>();
            SetFlourType();
            SetBakingTechnique();
            Type = type;
            Technique = technique;
            Weight = weight;
        }

        private double Weight
        {
            get => weight;
            set
            {
                if (!WeightRange(value))
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                weight = value;
            }
        }
        private double TypeValue => flourType[this.Type];
        private double TechniqueValue => bakingTechnique[this.Technique];
        private string Type 
        {
            get => type;
            set 
            {
                if (!flourType.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough.");
                type = value.ToLower();
            }
        }
        private string Technique 
        { 
            get => technique;
            set
            {
                if (!bakingTechnique.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough.");
                technique = value.ToLower();
            }
        }

        private void SetFlourType()
        {
            this.flourType.Add("wholegrain", 1);
            this.flourType.Add("white", 1.5);
        }
        private void SetBakingTechnique()
        {
            this.bakingTechnique.Add("crispy",0.9);
            this.bakingTechnique.Add("chewy",1.1);
            this.bakingTechnique.Add("homemade",1);
        }
        private bool WeightRange(double value) => value >= 1 && value <= 200;
        public double GetCalories()=> BASE_CALORIES * Weight * TypeValue * TechniqueValue;
    }
}
