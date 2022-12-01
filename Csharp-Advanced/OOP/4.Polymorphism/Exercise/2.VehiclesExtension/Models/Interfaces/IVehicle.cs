namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; set; }
        int TankCapacity { get; }
        string Drive(double distance);
        void Refuel(double liters);
    }
}