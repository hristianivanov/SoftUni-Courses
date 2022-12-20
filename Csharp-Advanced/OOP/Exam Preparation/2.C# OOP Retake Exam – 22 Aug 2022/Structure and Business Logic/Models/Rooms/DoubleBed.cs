namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int DOUBLEBED_CAPACITY = 2;
        public DoubleBed() 
            : base(DOUBLEBED_CAPACITY)
        {
        }
    }
}
