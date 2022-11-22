namespace Telephony
{
    using System;

    using Models;

    public class Program
    {
        static void Main(string[] args)
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            foreach (string number in numbers)
                if (number.Length == 7)
                    stationaryPhone.Call(number);
                else if (number.Length == 10)
                    smartphone.Call(number);

            foreach (string site in sites)
                smartphone.BrowseURL(site);
        }
    }
}
