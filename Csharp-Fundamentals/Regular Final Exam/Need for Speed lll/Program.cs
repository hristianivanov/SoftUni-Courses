using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed_lll
{
    internal class Program
    {
        public class Car
        {
            public Car(string model, int mileage, int fuel)
            {
                Model = model;
                Mileage = mileage;
                Fuel = fuel;
            }

            public string Model { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> list = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("|").ToList();

                Car car = new Car(input[0], int.Parse(input[1]), int.Parse(input[2]));

                list.Add(car);
            }

            var commands = Console.ReadLine().Split(" : ").ToList();

            while (commands[0] != "Stop")
            {
                if (commands[0] == "Drive")
                {
                    Car car = list.FirstOrDefault(x => x.Model == commands[1]);

                    if (car.Mileage + int.Parse(commands[2]) >= 100_000)
                    {
                        Console.WriteLine($"{car.Model} driven for {int.Parse(commands[2])} kilometers. {int.Parse(commands[3])} liters of fuel consumed.");
                        Console.WriteLine($"Time to sell the {car.Model}!");
                        list.Remove(car);
                    }
                    else if (car.Fuel >= int.Parse(commands[3]))
                    {
                        Console.WriteLine($"{car.Model} driven for {int.Parse(commands[2])} kilometers. {int.Parse(commands[3])} liters of fuel consumed.");
                        car.Mileage += int.Parse(commands[2]);
                        car.Fuel -= int.Parse(commands[3]);
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }

                if (commands[0] == "Refuel")
                {
            
                    const int MaxFuelTank = 75;

                    Car car = list.FirstOrDefault(x => x.Model == commands[1]);
                    var refuelled = int.Parse(commands[2]);

                    if (car.Fuel + refuelled > MaxFuelTank)
                    {
                        Console.WriteLine($"{car.Model} refueled with {75 - car.Fuel} liters");
                        car.Fuel = MaxFuelTank;
                    }
                    else
                    {
                        Console.WriteLine($"{car.Model} refueled with {refuelled} liters");
                        car.Fuel += refuelled;
                    }
                }

                if (commands[0] == "Revert")
                {
                    Car car = list.FirstOrDefault(x => x.Model == commands[1]);
                    var revertedKM = int.Parse(commands[2]);

                    if (car.Mileage - revertedKM < 10_000)
                    {
                        car.Mileage = 10_000;
                    }
                    else
                    {
                        car.Mileage -= revertedKM;
                        Console.WriteLine($"{car.Model} mileage decreased by {revertedKM} kilometers");
                    }

                }

                commands = Console.ReadLine().Split(" : ").ToList();
            }


            list.ForEach(car => Console.WriteLine($"{car.Model} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt."));

        }
    }
}
