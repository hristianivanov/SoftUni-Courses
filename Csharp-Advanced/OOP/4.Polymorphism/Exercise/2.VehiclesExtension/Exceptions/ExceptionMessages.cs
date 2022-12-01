namespace VehiclesExtension.Exceptions
{
    public static class ExceptionMessages
    {
        public const string NeededFuelExceptionMessage =
            "{0} needs refueling";

        public const string InvalidFuelValueExceptionMessage =
            "Fuel must be a positive number";

        public const string TankCapacityExceptionMessage =
            "Cannot fit {0} fuel in the tank";

        public const string InvalidVehicleTypeMessage =
            "Invalid vehicle type!";
    }
}
