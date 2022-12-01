namespace Vehicles.Models
{
    using Exceptions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption,
              double increasement)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + increasement;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (neededFuel > this.FuelQuantity)
            {
                throw new InsufficientFuelException(string.Format(
                    ExceptionMessages.InsufficientFuelExceptionMessage, this.GetType().Name));
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
            => this.FuelQuantity += liters;
        public override string ToString()
            => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
