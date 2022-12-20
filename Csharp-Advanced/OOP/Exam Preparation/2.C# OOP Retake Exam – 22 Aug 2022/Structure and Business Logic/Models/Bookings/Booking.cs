namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;

    using Bookings.Contracts;
    using Rooms.Contracts;
    using Utilities.Messages;

    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }
        public IRoom Room { get; private set; }
        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                residenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value < 1)
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }
        public int BookingNumber { get; private set; }
        public string BookingSummary()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {Room.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {ResidenceDuration * Room.PricePerNight:F2} $");

            return stringBuilder.ToString();
        }
    }
}
