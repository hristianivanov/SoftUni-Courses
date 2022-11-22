using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected double AIR_CONDITIONER;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (TankCapacity < value)
                    fuelQuantity = 0;
                fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; private set; }
        public int TankCapacity { get; private set; }

        public virtual void Drive(double distance)
        {
            if ((FuelConsumption + AIR_CONDITIONER) * distance is var result && result <= FuelQuantity)
            {
                FuelQuantity -= result;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
                Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        public virtual void Refuel(double liters)
        {
            if (ValidateRefuelLiters(liters))
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (liters + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            FuelQuantity += liters;
        }

        public virtual bool ValidateRefuelLiters(double liters) => liters <= 0;
        public void Print() => Console.WriteLine($"{this.GetType().Name}: {FuelQuantity:f2}");
    }
}
