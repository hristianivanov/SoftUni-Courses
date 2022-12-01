using System;
using System.Runtime.Serialization;

namespace VehiclesExtension.Exceptions
{
    [Serializable]
    internal class TankCapacityException : Exception
    {
        public TankCapacityException()
        {
        }

        public TankCapacityException(string message) : base(message)
        {
        }

        public TankCapacityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TankCapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}