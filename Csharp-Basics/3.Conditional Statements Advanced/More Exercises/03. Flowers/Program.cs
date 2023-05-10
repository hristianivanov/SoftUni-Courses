using System;

internal class Program
{
    static void Main(string[] args)
    {
        int chryzz = int.Parse(Console.ReadLine());
        int roses = int.Parse(Console.ReadLine());
        int tulips = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        bool isHoliday = Console.ReadLine() == "Y";

        double total;
        if (season == "Spring" || season == "Summer")
            total = chryzz * 2.00 + roses * 4.10 + tulips * 2.50;
        else
            total = chryzz * 3.75 + roses * 4.50 + tulips * 4.15;
        if (isHoliday)
            total *= 1.15;

        if (tulips > 7 && season == "Spring")
            total *= 0.95;
        if (roses >= 10 && season == "Winter")
            total *= 0.90;
        if (chryzz + roses + tulips > 20)
            total *= 0.80;
        total += 2;

        Console.WriteLine($"{total:f2}");
    }
}