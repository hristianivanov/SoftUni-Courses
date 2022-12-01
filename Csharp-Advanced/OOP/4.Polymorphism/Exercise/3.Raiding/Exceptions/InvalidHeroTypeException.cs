namespace Raiding.Exceptions
{
    using System;
    public class InvalidHeroTypeException : Exception
    {
        public InvalidHeroTypeException()
        {

        }
        public InvalidHeroTypeException(string message)
            : base(message) 
        {

        }
    }
}
