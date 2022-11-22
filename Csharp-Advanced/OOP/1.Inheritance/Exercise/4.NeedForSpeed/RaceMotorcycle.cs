using System;
using System.Collections.Generic;
using System.Text;

namespace _4.NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double RACE_MOTORCYCLE_CONSUMPTION = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption { get => RACE_MOTORCYCLE_CONSUMPTION; }
    }
}
