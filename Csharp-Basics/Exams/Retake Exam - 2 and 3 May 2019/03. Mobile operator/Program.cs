using System;

public class Program
{
    static void Main()
    {
        string duration = Console.ReadLine();
        string type = Console.ReadLine();
        string internet = Console.ReadLine();
        int months = int.Parse(Console.ReadLine());
        double cost = 0;

        switch (type)
        {
            case "Small":
                if (duration == "one") cost = 9.98;
                else cost = 8.58;
                break;
            case "Middle":
                if (duration == "one") cost = 18.99;
                else cost = 17.09;
                break;
            case "Large":
                if (duration == "one") cost = 25.98;
                else cost = 23.59;
                break;
            case "ExtraLarge":
                if (duration == "one") cost = 35.99;
                else cost = 31.79;
                break;
        }

        if (internet == "yes")
        {
            if (cost <= 10) cost += 5.50;
            else if (cost <= 30) cost += 4.35;
            else cost += 3.85;
        }

        if (duration == "two") cost -= 0.0375 * cost;

        cost *= months;

        Console.WriteLine($"{cost:f2} lv.");
    }
}