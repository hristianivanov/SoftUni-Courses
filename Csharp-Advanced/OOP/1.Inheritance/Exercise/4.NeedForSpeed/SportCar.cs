using System;
using System.Collections.Generic;
using System.Text;

namespace _4.NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DEFAULT_SPORTCAR_CONSUMPTION = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double DefaultFuelConsumption { get => DEFAULT_SPORTCAR_CONSUMPTION; }
    }
}
