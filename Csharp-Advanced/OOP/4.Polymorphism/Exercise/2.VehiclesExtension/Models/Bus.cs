namespace VehiclesExtension.Models
{
    using VehiclesExtension.Exceptions;

    public class Bus : Vehicle
    {
        private const double BUS_INCREASMENT = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, BUS_INCREASMENT)
        {

        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= BUS_INCREASMENT;
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > FuelQuantity)
                throw new InvalidFuelValueException(string.Format(ExceptionMessages.NeededFuelExceptionMessage, this.GetType().Name));

            FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }
    }
}
