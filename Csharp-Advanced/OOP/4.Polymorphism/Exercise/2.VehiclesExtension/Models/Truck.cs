namespace VehiclesExtension.Models
{
    using VehiclesExtension.Exceptions;

    public class Truck : Vehicle
    {
        private const double TRUCK_INCREASMENT = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, TRUCK_INCREASMENT)
        {

        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
                throw new InvalidFuelValueException(ExceptionMessages.InvalidFuelValueExceptionMessage);

            if (FuelQuantity + liters > TankCapacity)
                throw new TankCapacityException(string.Format(ExceptionMessages.TankCapacityExceptionMessage, liters));

            FuelQuantity += liters * 0.95;
        }
    }
}
