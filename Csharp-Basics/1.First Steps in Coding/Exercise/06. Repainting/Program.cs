using System;

namespace SU_Resource
{
    internal class Program
    {
        static void Main()
        {
            double nylon = (double.Parse(Console.ReadLine()) + 2) * 1.50;
            double paint = double.Parse(Console.ReadLine()) * 14.50 * 1.10;
            double diluter = double.Parse(Console.ReadLine()) * 5.00;
            double bags = 0.40;
            double materialsCost = nylon + paint + diluter + bags;

            double workers = double.Parse(Console.ReadLine()) * (materialsCost * 0.30);

            Console.WriteLine(materialsCost + workers);
        }
    }
}


