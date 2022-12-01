namespace Vehicles.Models
{
    using System;
    public class Car : Vehicle
    {
        const double CAR_AIR_INCREASMENT = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption,CAR_AIR_INCREASMENT) 
        {

        }
    }
}
