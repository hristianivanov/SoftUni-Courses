using _4.NeedForSpeed;
using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(2312, 35);
            sportCar.Drive(2);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
