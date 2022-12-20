namespace Formula1.Models
{
    using System;

    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                model = value;
            }
        }
        public int Horsepower
        {
            get => horsepower;
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                horsepower = value;
            }
        }
        public double EngineDisplacement
        {
            get => engineDisplacement;
            private set
            {
                if (value < 1.60 || value > 2.00)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                engineDisplacement = value;
            }
        }
        public double RaceScoreCalculator(int laps)
            => EngineDisplacement / Horsepower * laps;
    }
}
