namespace Telephony.Models
{
    using System.Linq;
    using System;

    using Interfaces;
    public class StationaryPhone : IStationaryPhone
    {
        public void Call(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Dialing... {number}");
        }
    }
}