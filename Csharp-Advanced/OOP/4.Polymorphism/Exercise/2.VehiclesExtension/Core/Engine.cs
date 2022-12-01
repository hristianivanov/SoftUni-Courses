namespace VehiclesExtension.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Exceptions;
    using Interfaces;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            vehicles = new HashSet<IVehicle>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }


        public void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                string[] input = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                double fuelQuantity = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                int tankCapacity = int.Parse(input[3]);

                IVehicle vehicle;
                if (input[0] == "Car")
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                else if (input[0] == "Truck")
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                else if (input[0] == "Bus")
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                else
                    throw new InvalidVehicleTypeException(ExceptionMessages.InvalidVehicleTypeMessage);

                vehicles.Add(vehicle);
            }

            int commandCnt = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandCnt; i++)
            {
                string[] cmdArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                string type = cmdArgs[1];
                double value = double.Parse(cmdArgs[2]);

                IVehicle vehicle = vehicles.SingleOrDefault(v => v.GetType().Name == type);
                if (vehicle == null)
                    throw new InvalidVehicleTypeException(ExceptionMessages.InvalidVehicleTypeMessage);
                try
                {
                    switch (command)
                    {
                        case "Drive": writer.WriteLine(vehicle.Drive(value)); break;
                        case "DriveEmpty":
                            var bus = vehicle as Bus;
                            if (bus != null)
                                writer.WriteLine(bus.DriveEmpty(value)); break;
                        case "Refuel": vehicle.Refuel(value); break;
                    }
                }
                catch (InvalidFuelValueException ifve)
                {
                    writer.WriteLine(ifve.Message);
                }
                catch (TankCapacityException tce)
                {
                    writer.WriteLine(tce.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle);
            }
        }
    }
}
