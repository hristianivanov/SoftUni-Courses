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

            public Car()
            {
              this.Make = "VW";
              this.Model = "Golf";
              this.Year = 2025;
              this.FuelQuantity = 200;
              this.FuelConsumption = 10;
            }
            public Car(string make, string model, int year):this()
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
            }

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
            {
                this.FuelQuantity = fuelQuantity;
                this.FuelConsumption = fuelConsumption;
            }

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
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make,model,year,fuelQuantity,fuelConsumption);
        }
    }
}
