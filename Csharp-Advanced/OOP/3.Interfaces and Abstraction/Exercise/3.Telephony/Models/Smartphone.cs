namespace Telephony.Models
{
    using System.Linq;
    using System;

    using Interfaces;
    public class Smartphone : ISmartphone
    {
       
        public void Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Calling... {phoneNumber}");
        }
        public void BrowseURL(string url)
        {
            if (!ValidateURL(url))
                Console.WriteLine("Invalid URL!");
            else
                Console.WriteLine($"Browsing: {url}!");
        }


        private bool ValidatePhoneNumber(string phoneNumber)
           => phoneNumber.All(ch => char.IsDigit(ch));

        private bool ValidateURL(string url)
            => url.All(ch => !char.IsDigit(ch));
    }
}