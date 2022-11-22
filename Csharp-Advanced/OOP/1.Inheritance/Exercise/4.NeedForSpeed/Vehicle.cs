using System;
using System.Collections.Generic;
using System.Text;

namespace _4.NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public void Drive(double kilometers)
        {
            this.Fuel-= DefaultFuelConsumption * kilometers;
        }
        public virtual double DefaultFuelConsumption { get => DEFAULT_FUEL_CONSUMPTION; }
        public double Fuel { get => fuel; set => fuel = value; }
        public int HorsePower { get => horsePower; set => horsePower = value; }
    }
}
