using System;

internal class Program
{
    static void Main(string[] args)
    {
        string season = Console.ReadLine();
        double kmMonth = double.Parse(Console.ReadLine());
        double total = kmMonth * 1.45;

        if (kmMonth <= 5000)
        {
            switch (season)
            {
                case "Spring":
                case "Autumn": total = kmMonth * 0.75; break;
                case "Summer": total = kmMonth * 0.90; break;
                case "Winter": total = kmMonth * 1.05; break;
            }
        }
        else if (kmMonth <= 10000)
        {
            switch (season)
            {
                case "Spring":
                case "Autumn": total = kmMonth * 0.95; break;
                case "Summer": total = kmMonth * 1.10; break;
                case "Winter": total = kmMonth * 1.25; break;
            }
        }
        total *= 4;
        total *= 0.9;
        Console.WriteLine("{0:f2}", total);
    }
}