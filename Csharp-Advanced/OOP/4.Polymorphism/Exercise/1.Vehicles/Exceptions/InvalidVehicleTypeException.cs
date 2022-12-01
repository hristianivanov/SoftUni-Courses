namespace Vehicles.Exceptions
{
    using System;
    internal class InvalidVehicleTypeException : Exception
    {
        public InvalidVehicleTypeException()
        {

        }

        public InvalidVehicleTypeException(string message)
            : base(message)
        {

        }
    }
}