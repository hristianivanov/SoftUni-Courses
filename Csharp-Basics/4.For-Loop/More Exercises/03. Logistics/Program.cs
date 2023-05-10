using System;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int van = 0, truck = 0, train = 0;
        double price = 0;

        for (int i = 0; i < n; i++)
        {
            int cargo = int.Parse(Console.ReadLine());

            if (cargo <= 3)
                van += cargo; price += cargo * 200;
            else if (cargo <= 11)
                truck += cargo; price += cargo * 175;
            else
                train += cargo; price += cargo * 120;
        }

        int totalCargo = van + truck + train;
        Console.WriteLine($"{price / (double)totalCargo:f2}");
        Console.WriteLine($"{van * 100.0 / totalCargo:f2}%");
        Console.WriteLine($"{truck * 100.0 / totalCargo:f2}%");
        Console.WriteLine($"{train * 100.0 / totalCargo:f2}%");
    }
}