namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption,int tankCapacity) : base(fuelQuantity, fuelConsumption,tankCapacity) 
        {
            base.AIR_CONDITIONER = 1.6;
        }
    }
}
