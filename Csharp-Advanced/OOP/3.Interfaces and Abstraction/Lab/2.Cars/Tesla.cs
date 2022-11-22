using System;

namespace Cars
{
    internal class Tesla : ICar,IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public string Start() => "Engine start";

        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery}" + $"{Environment.NewLine}{Start()}" + $"{Environment.NewLine}{Stop()}";
        }
    }
}