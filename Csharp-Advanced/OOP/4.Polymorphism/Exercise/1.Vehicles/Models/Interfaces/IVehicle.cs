namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        public void Refuel(double liters);
        public string Drive(double distance);
    }
}