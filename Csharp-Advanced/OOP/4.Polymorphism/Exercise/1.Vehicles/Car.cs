namespace Vehicles
{
    using System;
    public class Car : Vehicle
    {
        const double CAR_AIR_INCREASMENT = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption) { }

        public override void Drive(double distance)
        {
            if ((FuelConsumption + CAR_AIR_INCREASMENT) * distance is var result && result <= FuelQuantity)
            {
                FuelQuantity -= result;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
                Console.WriteLine("Car needs refueling");
        }

        public override void Refuel(double liters) => FuelQuantity += liters;

        public void Print() => Console.WriteLine($"Car: {FuelQuantity:f2}");
    }
}
