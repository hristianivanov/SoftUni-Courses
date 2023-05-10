using System;

public class Program
{
    public static void Main()
    {
        string flower = Console.ReadLine();
        int amount = int.Parse(Console.ReadLine());
        int budget = int.Parse(Console.ReadLine());
        double total = 0;

        switch (flower)
        {
            case "Roses":
                total = amount * 5.00;
                if (amount > 80) total -= 0.1 * total;
                break;
            case "Dahlias":
                total = amount * 3.80;
                if (amount > 90) total -= 0.15 * total;
                break;
            case "Tulips":
                total = amount * 2.80;
                if (amount > 80) total -= 0.15 * total;
                break;
            case "Narcissus":
                total = amount * 3.00;
                if (amount < 120) total += 0.15 * total;
                break;
            case "Gladiolus":
                total = amount * 2.50;
                if (amount < 80) total += 0.2 * total;
                break;
        }

        if (budget >= total)
            Console.WriteLine("Hey, you have a great garden with {0} {1} and {2:f2} leva left.", amount, flower, budget - total);
        else
            Console.WriteLine("Not enough money, you need {0:f2} leva more.", total - budget);
    }
}