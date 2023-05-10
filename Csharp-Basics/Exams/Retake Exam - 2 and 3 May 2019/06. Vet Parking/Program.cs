using System;

public class Program
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        double total = 0;

        for (int i = 1; i <= days; i++)
        {
            double dayCost = 0;
            for (int j = 1; j <= hours; j++)
            {
                if (i % 2 == 0 && j % 2 == 1)
                    dayCost += 2.50;
                else if (i % 2 == 1 && j % 2 == 0)
                    dayCost += 1.25;
                else 
                    dayCost += 1.00;
            }
            Console.WriteLine($"Day: {i} - {dayCost:f2} leva");
            total += dayCost;
        }
        Console.WriteLine($"Total: {total:f2} leva");
    }
}