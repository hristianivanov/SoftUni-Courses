using System;

public class Program
{
    static void Main()
    {
        int budget = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        int fishermen = int.Parse(Console.ReadLine());
        double rentPrice = 0;
        double priceWithDiscount = 0;

        switch (season)
        {
            case "Spring":
                rentPrice = 3000;
                if (fishermen <= 6)
                    priceWithDiscount = rentPrice - rentPrice * 0.1;
                else if (fishermen >= 7 && fishermen <= 11)
                    priceWithDiscount = rentPrice - rentPrice * 0.15;
                else if (fishermen >= 12)
                    priceWithDiscount = rentPrice - rentPrice * 0.25;
                break;
            case "Summer":
            case "Autumn":
                rentPrice = 4200;
                if (fishermen <= 6)
                    priceWithDiscount = rentPrice - rentPrice * 0.1;
                else if (fishermen >= 7 && fishermen <= 11)
                    priceWithDiscount = rentPrice - rentPrice * 0.15;
                else if (fishermen >= 12)
                    priceWithDiscount = rentPrice - rentPrice * 0.25;
                break;
            case "Winter":
                rentPrice = 2600;
                if (fishermen <= 6)
                    priceWithDiscount = rentPrice - rentPrice * 0.1;
                else if (fishermen >= 7 && fishermen <= 11)
                    priceWithDiscount = rentPrice - rentPrice * 0.15;
                else if (fishermen >= 12)
                    priceWithDiscount = rentPrice - rentPrice * 0.25;
                break;
        }

        if (fishermen % 2 == 0 && season != "Autumn")
            priceWithDiscount = priceWithDiscount - priceWithDiscount * 0.05;
        if (budget >= priceWithDiscount)
        {
            double moneyLeft = budget - priceWithDiscount;
            Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
        }
        else if (budget < priceWithDiscount)
        {
            double moneyNotEnough = priceWithDiscount - budget;
            Console.WriteLine($"Not enough money! You need {moneyNotEnough:f2} leva.");
        }
    }
}
