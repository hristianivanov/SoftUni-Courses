using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIR_INCREASMENT = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption) { }

        public override void Drive(double distance)
        {
            if ((FuelConsumption + TRUCK_AIR_INCREASMENT) * distance is var result && result <= FuelQuantity)
            {
                FuelQuantity -= result;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
                Console.WriteLine("Truck needs refueling");
        }

        public override void Refuel(double liters) => FuelQuantity += liters * 0.95;
        public void Print() => Console.WriteLine($"Truck: {FuelQuantity:f2}");
    }
}
