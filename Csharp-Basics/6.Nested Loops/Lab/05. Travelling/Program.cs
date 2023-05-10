using System;

internal class Program
{
    static void Main()
    {
        string destination = Console.ReadLine();

        while (destination != "End")
        {
            double holidayCost = double.Parse(Console.ReadLine());
            double saved = 0;
            while (saved < holidayCost)
            {
                double num = double.Parse(Console.ReadLine());
                saved += num;
            }
            Console.WriteLine($"Going to {destination}!");
            destination = Console.ReadLine();
        }
    }
}