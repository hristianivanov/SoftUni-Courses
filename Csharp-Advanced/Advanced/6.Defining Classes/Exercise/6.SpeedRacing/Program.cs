using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var carProps = Console.ReadLine().Split();
                Car car = new Car(carProps[0], double.Parse(carProps[1]), double.Parse(carProps[2]));
                cars.Add(carProps[0], car);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = cars[splitted[1]];
                car.Drive(int.Parse(splitted[2]));
            }
            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
