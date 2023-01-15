using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string command = input.Split(", ").First();
                string car = input.Split(", ").Last();

                if (command == "IN")
                {
                    cars.Add(car);
                }
                else if (command == "OUT")
                {
                    cars.Remove(car);
                }

                input = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
