namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double CAR_INCREASMENT = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity, CAR_INCREASMENT)
        {

        }
    }
}
