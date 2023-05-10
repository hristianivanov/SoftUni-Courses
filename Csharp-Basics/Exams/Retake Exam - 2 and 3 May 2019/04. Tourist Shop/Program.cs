using System;

public class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int products = 0;
        double total = 0;

        while (input != "Stop")
        {
            double price = double.Parse(Console.ReadLine());
            if ((products + 1) % 3 == 0) price /= 2;
            total += price;
            if (budget < total) break;
            products++;
            input = Console.ReadLine();
        }

        if (budget < total)
        {
            Console.WriteLine($"You don't have enough money!");
            Console.WriteLine($"You need {(total - budget):f2} leva!");
        }
        else Console.WriteLine($"You bought {products} products for {total:f2} leva.");
    }
}