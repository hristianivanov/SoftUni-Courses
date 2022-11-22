namespace Vehicles
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string[] cmdArgs;
        static void Main(string[] args)
        {
            cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            Vehicle car = new Car(double.Parse(cmdArgs[0]), double.Parse(cmdArgs[1]));

            cmdArgs = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Skip(1)
               .ToArray();

            Vehicle truck = new Truck(double.Parse(cmdArgs[0]), double.Parse(cmdArgs[1]));

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string type = input[1];
                double value = double.Parse(input[2]);

                if (type == "Car")
                {
                    if (command == "Drive")
                        car.Drive(value);
                    else
                        car.Refuel(value);
                }
                else
                {
                    if (command == "Drive")
                        truck.Drive(value);
                    else
                        truck.Refuel(value);
                }
            }

            ((Car)car).Print();
            ((Truck)truck).Print();
        }
    }
}
