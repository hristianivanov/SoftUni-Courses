namespace BookingApp.Models.Rooms
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Room : IRoom
    {
        private double pricePerNight;
        public int BedCapacity { get; private set; }
        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }
        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative, value));
                pricePerNight = value;
            }
        }
        public void SetPrice(double price)
            => PricePerNight = price;
    }
}
