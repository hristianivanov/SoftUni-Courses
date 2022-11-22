namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.AIR_CONDITIONER = 0.9;
        }
    }
}
