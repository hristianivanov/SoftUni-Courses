using System;

public class Program
{
    static void Main()
    {
        double heavy = double.Parse(Console.ReadLine());
        double kg = double.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int amount = int.Parse(Console.ReadLine());
        double price = 0;

        if (kg < 10) price = 0.2 * heavy;
        else if (kg <= 20) price = 0.5 * heavy;
        else price = heavy;

        if (days > 30) price *= 1.10;
        else if (days >= 7) price *= 1.15;
        else price *= 1.40;

        Console.WriteLine($"The total price of bags is: {price * amount:f2} lv.");
    }
}