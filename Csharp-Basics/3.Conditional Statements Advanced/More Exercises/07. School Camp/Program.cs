using System;

internal class Program
{
    static void Main(string[] args)
    {
        string season = Console.ReadLine();
        string type = Console.ReadLine();
        int students = int.Parse(Console.ReadLine());
        int nights = int.Parse(Console.ReadLine());
        double price = 0;
        string sport = string.Empty;

        if (type == "boys")
        {
            switch (season)
            {
                case "Winter": price = 9.60; sport = "Judo"; break;
                case "Spring": price = 7.20; sport = "Tennis"; break;
                case "Summer": price = 15.00; sport = "Football"; break;
            }
        }
        else if (type == "girls")
        {
            switch (season)
            {
                case "Winter": price = 9.60; sport = "Gymnastics"; break;
                case "Spring": price = 7.20; sport = "Athletics"; break;
                case "Summer": price = 15.00; sport = "Volleyball"; break;
            }
        }

        else switch (season)
            {
                case "Winter": price = 10.00; sport = "Ski"; break;
                case "Spring": price = 9.50; sport = "Cycling"; break;
                case "Summer": price = 20.00; sport = "Swimming"; break;
            }

        double total = price * nights * students;

        if (students >= 50)
            total *= 0.50;
        else if (students >= 20)
            total *= 0.85;
        else if (students >= 10)
            total *= 0.95;

        Console.WriteLine($"{sport} {total:f2} lv.");
    }
}