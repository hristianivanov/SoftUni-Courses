
namespace VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                string[] data = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = data[0];
                double fuelQuantity = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);
                int tankCapacity = int.Parse(data[3]);

                Vehicle vehicle = null;
                switch (type)
                {
                    case "Car": vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity); break;
                    case "Truck": vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity); break;
                    case "Bus": vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity); break;
                }

                vehicles.Add(vehicle);
            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                string type = cmdArgs[1];
                var value = int.Parse(cmdArgs[2]);

                Vehicle vehicle;
                vehicle = vehicles.Single(v => v.GetType().Name == type);

                switch (command)
                {
                    case "Drive": vehicle.Drive(value); break;
                    case "DriveEmpty": ((Bus)vehicle).DriveEmpty(value); break;
                    case "Refuel": vehicle.Refuel(value); break;
                }
            }

            vehicles.ForEach(v => v.Print());
        }
    }
}
