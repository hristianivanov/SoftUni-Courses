namespace BookingApp.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories;
    using Models.Bookings;
    using Models.Bookings.Contracts;
    using Models.Hotels;
    using Models.Hotels.Contacts;
    using Models.Rooms;
    using Models.Rooms.Contracts;


    public class Controller : IController
    {
        private HotelRepository hotelRepository;
        public Controller()
        {
            hotelRepository = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotelRepository.Select(hotelName) != null)
                return $"Hotel {hotelName} is already registered in our platform.";

            IHotel hotel = new Hotel(hotelName, category);
            hotelRepository.AddNew(hotel);
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }
        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = hotelRepository.All()
                .Where(x => x.Category == category)
                .OrderBy(x => x.FullName)
                .ToList();
            if (orderedHotels.Count == 0)
                return $"{category} star hotel is not available in our platform.";
            IHotel hotel = orderedHotels.FirstOrDefault(x => x.Rooms.All().Any(x => x.PricePerNight > 0));

            var hotelRooms = hotel.Rooms.All().Where(x => x.PricePerNight > 0)
                .OrderBy(x => x.BedCapacity)
                .ToList();

            IRoom room = hotelRooms.FirstOrDefault(x => x.BedCapacity >= adults + children);
            if (room == null)
                return $"We cannot offer appropriate room for your request.";

            int bookingNumber = hotel.Bookings.All().Count + 1;
            IBooking booking = new Booking(room, duration, adults, children, bookingNumber);
            hotel.Bookings.AddNew(booking);
            return $"Booking number {bookingNumber} for {hotel.FullName} hotel is successful!";
        }
        public string HotelReport(string hotelName)
        {
            if (hotelRepository.Select(hotelName) == null)
                return $"Profile {hotelName} doesn’t exist!";
            IHotel hotel = hotelRepository.Select(hotelName);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Hotel name: {hotelName}")
            .AppendLine($"--{hotel.Category} star hotel")
            .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
            .AppendLine($"--Bookings:")
            .AppendLine();

            if (hotel.Bookings.All().Count > 0)
            {
                foreach (var booking in hotel.Bookings.All())
                    stringBuilder.AppendLine(booking.BookingSummary());
            }
            else
                stringBuilder.AppendLine("none");

            return stringBuilder.ToString().Trim();
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotelRepository.Select(hotelName) == null)
                return $"Profile {hotelName} doesn’t exist!";
            IHotel hotel = hotelRepository.Select(hotelName);

            IRoom room = null;
            switch (roomTypeName)
            {
                case nameof(DoubleBed): room = hotel.Rooms.Select(roomTypeName); break;
                case nameof(Studio): room = hotel.Rooms.Select(roomTypeName); break;
                case nameof(Apartment): room = hotel.Rooms.Select(roomTypeName); break;
                default: return "Incorrect room type!";
            }
            if (room == null)
                return "Room type is not created yet!";
            if (room.PricePerNight != 0)
                throw new InvalidOperationException("Price is already set!");

            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotelRepository.Select(hotelName) == null)
                return $"Profile {hotelName} doesn’t exist!";

            IHotel hotel = hotelRepository.Select(hotelName);
            if (hotel.Rooms.Select(roomTypeName) != null)
                return "Room type is already created!";

            IRoom room = null;
            switch (roomTypeName)
            {
                case nameof(DoubleBed): room = new DoubleBed(); break;
                case nameof(Studio): room = new Studio(); break;
                case nameof(Apartment): room = new Apartment(); break;
                default: return "Incorrect room type!";
            }

            hotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
