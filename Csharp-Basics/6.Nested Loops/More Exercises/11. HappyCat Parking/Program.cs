using System;

public class Program
{
    public static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        double total = 0;

        for (int day = 1; day <= days; day++)
        {
            double sumDay = 0;
            for (int hour = 1; hour <= hours; hour++)
            {
                if (day % 2 == 0 && hour % 2 == 1) sumDay += 2.50;
                else if (day % 2 == 1 && hour % 2 == 0) sumDay += 1.25;
                else sumDay += 1.00;
            }
            Console.WriteLine("Day: {0} - {1:f2} leva", day, sumDay);
            total += sumDay;
        }
        Console.WriteLine("Total: {0:f2} leva", total);
    }
}