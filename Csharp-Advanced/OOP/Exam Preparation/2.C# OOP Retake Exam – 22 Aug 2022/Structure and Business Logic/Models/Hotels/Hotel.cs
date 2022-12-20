

namespace BookingApp.Models.Hotels
{
    using System;
    using System.Linq;

    using Repositories;
    using Bookings.Contracts;
    using Hotels.Contacts;
    using Rooms.Contracts;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private RoomRepository roomRepository;
        private BookingRepository bookingRepository;
        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.roomRepository = new RoomRepository();
            this.bookingRepository = new BookingRepository();
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                fullName = value;
            }
        }
        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                category = value;
            }
        }
        public double Turnover
            => Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight);
        public IRepository<IRoom> Rooms
            => roomRepository;
        public IRepository<IBooking> Bookings
            => bookingRepository;
    }
}
