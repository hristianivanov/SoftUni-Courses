using System;

public class Program
{
    public static void Main()
    {
        int months = int.Parse(Console.ReadLine());
        double electricity = 0;
        double water = months * 20;
        double internet = months * 15;

        for (int i = 0; i < months; i++)
            electricity += double.Parse(Console.ReadLine());

        double other = (electricity + water + internet) * 1.2;
        double totalAvg = (electricity + water + internet + other) / months;

        Console.WriteLine("Electricity: {0:f2} lv", electricity);
        Console.WriteLine("Water: {0:f2} lv", water);
        Console.WriteLine("Internet: {0:f2} lv", internet);
        Console.WriteLine("Other: {0:f2} lv", other);
        Console.WriteLine("Average: {0:f2} lv", totalAvg);
    }
}