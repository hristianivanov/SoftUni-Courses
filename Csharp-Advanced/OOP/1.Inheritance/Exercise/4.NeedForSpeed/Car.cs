using System;
using System.Collections.Generic;
using System.Text;

namespace _4.NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DEFAULT_CAR_CONSUMPTION = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption { get => DEFAULT_CAR_CONSUMPTION; }
    }
}
