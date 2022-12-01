namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using IO.Interfaces;
    using Exceptions;
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
            for (int i = 0; i < 2; i++)
            {
                string[] cmdArgs = reader.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IVehicle vehicle;
                if (cmdArgs[0] == "Car")
                    vehicle = new Car(double.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                else if (cmdArgs[0] == "Truck")
                    vehicle = new Truck(double.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                else
                    throw new InvalidVehicleTypeException(ExceptionMessages.InvalidVehicleTypeMessage);

                vehicles.Add(vehicle);
            }

            int count = int.Parse(reader.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string type = input[1];
                double value = double.Parse(input[2]);

                IVehicle vehicle = vehicles.SingleOrDefault(v=>v.GetType().Name == type);
                if (vehicle == null)
                    throw new InvalidVehicleTypeException(ExceptionMessages.InvalidVehicleTypeMessage);
                try
                {
                    if (command == "Drive")
                        writer.WriteLine(vehicle.Drive(value));
                    else if (command == "Refuel")
                        vehicle.Refuel(value);
                }
                catch (InsufficientFuelException ife)
                {
                    writer.WriteLine(ife.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle);
            }
        }
    }
}
