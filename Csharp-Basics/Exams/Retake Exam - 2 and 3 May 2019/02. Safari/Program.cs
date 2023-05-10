using System;

public class Program
{
    public static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        double fuel = double.Parse(Console.ReadLine());
        string day = Console.ReadLine();

        double total = fuel * 2.10 + 100.00;
        if (day == "Saturday") total -= total * 0.10;
        if (day == "Sunday") total -= total * 0.20;

        if (budget >= total)
            Console.WriteLine("Safari time! Money left: {0:f2} lv. ", budget - total);
        else
            Console.WriteLine("Not enough money! Money needed: {0:f2} lv.", total - budget);
    }
}