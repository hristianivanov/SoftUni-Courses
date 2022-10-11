using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace CarManufacturer
{
    public class StartUp
    {
        class Car
        {
            private string make;
            private string model;
            private int year;
            private double fuelQuantity;
            private double fuelConsumption;

            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double FuelQuantity { get; set; }
            public double FuelConsumption { get; set; }


            public void Drive(double distance)
            {
                double leftFuel = FuelQuantity - distance * FuelConsumption;
                if (leftFuel<0)
                {
                    Console.WriteLine("Not enough fuel to perform this trip!");
                    return;
                }
                FuelQuantity = leftFuel;
            }
            public string WhoAmI()
            {
                return $"Make: {this.Make}\nModel: { this.Model}\nYear: { this.Year}\nFuel: { this.FuelQuantity:F2}";
            }
        }

        static void Main()
        {

        }
    }
}
