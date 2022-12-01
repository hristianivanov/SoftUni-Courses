namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIR_INCREASMENT = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, TRUCK_AIR_INCREASMENT)
        {

        }

        public override void Refuel(double liters)
            => base.Refuel(liters * 0.95);
    }
}
