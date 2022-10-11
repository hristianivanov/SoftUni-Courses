using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    internal class Program
    {
        public class Vehicle
        {
            public Vehicle(string type, string model, string color, int horsePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsePower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
               
                stringBuilder.AppendLine($"Type: {(this.Type == "car" ? "Car" : "Truck")}");
                stringBuilder.AppendLine($"Model: {this.Model}");
                stringBuilder.AppendLine($"Color: {this.Color}");
                stringBuilder.Append($"Horsepower: {this.HorsePower}");

                return stringBuilder.ToString();
            }
        }
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                var currentVehicle = new Vehicle(input[0].ToLower(),
                    input[1],
                    input[2].ToLower(),
                    int.Parse(input[3])
                    );

                catalogue.Add(currentVehicle);

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string model = Console.ReadLine();

            while (model != "Close the Catalogue")
            {
                Console.WriteLine(catalogue.Find(x => x.Model == model));

                model = Console.ReadLine();
            }

            List<Vehicle> cars = catalogue.Where(x => x.Type == "car").ToList();

            List<Vehicle> trucks = catalogue.Where(x => x.Type == "truck").ToList();


            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {cars.Average(x => x.HorsePower):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucks.Average(x => x.HorsePower):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
