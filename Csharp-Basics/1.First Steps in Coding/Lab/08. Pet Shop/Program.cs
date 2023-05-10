using System;

namespace Presentation
{
    internal class Program
    {
        static void Main()
        {
            int dogNumber = int.Parse(Console.ReadLine());
            int catNumber = int.Parse(Console.ReadLine());
            double dogfoodPrice = 2.50;
            double catfoodPrice = 4.00;

            double total = dogNumber * dogfoodPrice + catNumber * catfoodPrice;
            Console.WriteLine($"{total} lv.");
        }
    }
}
