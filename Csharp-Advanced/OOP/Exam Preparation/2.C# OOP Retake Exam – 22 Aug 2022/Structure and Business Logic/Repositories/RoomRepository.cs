namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Rooms.Contracts;
    using Repositories.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;
        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }
        public void AddNew(IRoom room)
            => rooms.Add(room);
        public IReadOnlyCollection<IRoom> All()
            => rooms.AsReadOnly();
        public IRoom Select(string roomTypeName)
            => rooms.FirstOrDefault(x => x.GetType().Name == roomTypeName);

    }
}
