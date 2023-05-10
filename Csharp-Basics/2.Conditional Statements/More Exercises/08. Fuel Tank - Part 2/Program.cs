using System;

internal class Program
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine();
        double amount = double.Parse(Console.ReadLine());
        bool hasCard = Console.ReadLine() == "Yes";
        double price = 0;

        switch (type)
        {
            case "Gasoline": price = 2.22; if (hasCard) price -= 0.18; break;
            case "Diesel": price = 2.33; if (hasCard) price -= 0.12; break;
            case "Gas": price = 0.93; if (hasCard) price -= 0.08; break;
        }

        price *= amount;

        if (amount > 25)
            price *= 0.90;
        else if (amount >= 20)
            price *= 0.92;

        Console.WriteLine($"{price:f2} lv.");
    }
}