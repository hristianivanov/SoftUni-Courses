namespace Vehicles.Exceptions
{
    using System;

    internal class InsufficientFuelException : Exception
    {
        public InsufficientFuelException()
        {

        }
        public InsufficientFuelException(string message) 
            : base(message)
        {

        }
    }
}