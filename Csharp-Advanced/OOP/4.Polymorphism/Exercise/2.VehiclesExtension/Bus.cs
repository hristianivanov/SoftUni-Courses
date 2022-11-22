namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.AIR_CONDITIONER = 1.4;
        }

        public void DriveEmpty(double distance)
        {
            base.AIR_CONDITIONER = 0;
            base.Drive(distance);
        }



    }
}
