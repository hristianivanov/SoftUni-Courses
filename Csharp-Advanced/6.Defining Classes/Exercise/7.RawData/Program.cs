using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carProperties[0];
                int speed = int.Parse(carProperties[1]);
                int power = int.Parse(carProperties[2]);
                int weight = int.Parse(carProperties[3]);
                string type = carProperties[4];
                Tyre[] tyres = new Tyre[] {
                    new Tyre { Pressure = double.Parse(carProperties[5]),Age = int.Parse(carProperties[6])},
                    new Tyre { Pressure = double.Parse(carProperties[7]),Age = int.Parse(carProperties[8]) },
                    new Tyre { Pressure = double.Parse(carProperties[9]),Age = int.Parse(carProperties[10]) },
                    new Tyre { Pressure = double.Parse(carProperties[11]),Age = int.Parse(carProperties[12]) }
                };

                Car car = new Car(model,
                     new Engine { Speed = speed, Power = power },
                 new Cargo { Weight = weight, Type = type },
                 tyres);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            string[] filteredCarModels;

            if (command == "fragile")
            {
                filteredCarModels = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToArray();
            }
            else
            {
                filteredCarModels = cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToArray();
            }

            Console.WriteLine(string.Join(Environment.NewLine, filteredCarModels));
        }
    }
}
