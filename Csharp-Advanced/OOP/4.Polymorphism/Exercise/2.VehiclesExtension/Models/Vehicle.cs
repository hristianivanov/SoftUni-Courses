namespace VehiclesExtension.Models
{
    using Interfaces;
    using VehiclesExtension.Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity,
              double increasment)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + increasment;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                    fuelQuantity = 0;
                else
                    fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; set; }
        public int TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > FuelQuantity)
                throw new InvalidFuelValueException(string.Format(ExceptionMessages.NeededFuelExceptionMessage, this.GetType().Name));

            FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
                throw new InvalidFuelValueException(ExceptionMessages.InvalidFuelValueExceptionMessage);

            if (FuelQuantity + liters > TankCapacity)
                throw new TankCapacityException(string.Format(ExceptionMessages.TankCapacityExceptionMessage, liters));

            FuelQuantity += liters;
        }

        public override string ToString()
            => $"{GetType().Name}: {FuelQuantity:f2}";

    }
}
