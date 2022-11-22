using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string input;

            List<Car> cars = new List<Car>();
            List<Tire[]> tiresCollection = new List<Tire[]>();
            List<Engine> enginesCollection = new List<Engine>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                var tokens = input.Split();
                Tire[] tires = new Tire[4];
                int index = 0;
                for (int i = 0; i < tires.Length * 2; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);
                    tires[index++] = new Tire(year, pressure);
                }
                tiresCollection.Add(tires);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                var tokens = input.Split();

                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                enginesCollection.Add(new Engine(horsePower, cubicCapacity));
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                var tokens = input.Split();

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Tire[] currTire = tiresCollection[tiresIndex];
                Engine currEngine = enginesCollection[engineIndex];
                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, currEngine, currTire));
            }
            //drive 20 kilometers all the cars, which were manufactured
            //during 2017 or after, have horsepower above 330 and the sum
            //of their tire pressure is between 9 and 10.Finally, print
            //information about each special car in the following format:
            foreach (Car car in cars.FindAll(SpeacialFeatures()))
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

        }

        private static Predicate<Car> SpeacialFeatures()
        {
            return car => car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(x => x.Pressure) >= 9 &&
                        car.Tires.Sum(x => x.Pressure) <= 10;
        }
    }
}
