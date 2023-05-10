using System;

namespace SU_Resource
{
    internal class Program
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double stuffPercentage = double.Parse(Console.ReadLine()) / 100.0;

            double volume = lenght * width * height / 1000.0;
            double stuff = volume * stuffPercentage;

            double total = volume - stuff;

            Console.WriteLine(total);
        }
    }
}