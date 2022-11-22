namespace Telephony.Models.Interfaces
{
    public interface ISmartphone : IStationaryPhone
    {
        public void BrowseURL(string url);
    }
}