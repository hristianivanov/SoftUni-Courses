using System;

internal class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        string clas = "Luxury class";
        string type = "Jeep";
        double price = 0;

        if (budget <= 100)
        {
            clas = "Economy class";
            if (season == "Summer")
                type = "Cabrio"; price = 0.35 * budget;
            else
                price = 0.65 * budget;
        }
        else if (budget <= 500)
        {
            clas = "Compact class";
            if (season == "Summer")
                type = "Cabrio"; price = 0.45 * budget;
            else
                price = 0.80 * budget;
        }
        else
            price = 0.90 * budget;

        Console.WriteLine(clas);
        Console.WriteLine($"{type} - {price:f2}");
    }
}