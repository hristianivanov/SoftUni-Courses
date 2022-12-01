namespace VehiclesExtension.Exceptions
{
    using System;
    public class InvalidFuelValueException : Exception
    {
        public InvalidFuelValueException()
        {

        }

        public InvalidFuelValueException(string message)
            : base(message)
        {

        }
    }
}