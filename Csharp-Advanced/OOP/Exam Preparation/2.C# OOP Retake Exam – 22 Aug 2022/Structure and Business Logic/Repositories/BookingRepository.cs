namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Repositories.Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }
        public void AddNew(IBooking booking)
            => bookings.Add(booking);
        public IReadOnlyCollection<IBooking> All()
            => bookings.AsReadOnly();
        public IBooking Select(string bookingNumberToString)
            => bookings.FirstOrDefault(x => x.BookingNumber.ToString() == bookingNumberToString);
    }
}
