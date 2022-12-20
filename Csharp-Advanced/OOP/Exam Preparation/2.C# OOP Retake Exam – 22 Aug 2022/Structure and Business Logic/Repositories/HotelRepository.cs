namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Repositories.Contracts;
    using Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;
        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }
        public void AddNew(IHotel hotel)
            => hotels.Add(hotel);
        public IReadOnlyCollection<IHotel> All()
            => hotels.AsReadOnly();
        public IHotel Select(string hotelName)
            => hotels.FirstOrDefault(x => x.FullName == hotelName);
    }
}
