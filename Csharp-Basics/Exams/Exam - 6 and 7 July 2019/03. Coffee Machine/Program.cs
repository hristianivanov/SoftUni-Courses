using System;

public class Program
{
    public static void Main()
    {
        string drink = Console.ReadLine();
        string sugar = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());
        double price = 0;
        double total = 0;

        switch (sugar)
        {
            case "Without":
                if (drink == "Espresso") price = 0.90;
                else if (drink == "Cappuccino") price = 1.00;
                else price = 0.50;
                price *= 0.65;
                break;
            case "Normal":
                if (drink == "Espresso") price = 1.00;
                else if (drink == "Cappuccino") price = 1.20;
                else price = 0.60;
                break;
            case "Extra":
                if (drink == "Espresso") price = 1.20;
                else if (drink == "Cappuccino") price = 1.60;
                else price = 0.70;
                break;
        }
        if (drink == "Espresso" && quantity >= 5) price *= 0.75;
        total = price * quantity;
        if (total > 15.00) total *= 0.8;

        Console.WriteLine("You bought {0} cups of {1} for {2:f2} lv.", quantity, drink, total);
    }
}