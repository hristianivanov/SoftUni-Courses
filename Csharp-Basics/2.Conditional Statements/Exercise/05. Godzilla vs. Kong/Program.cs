using System;


internal class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        int people = int.Parse(Console.ReadLine());
        double priceClothing = double.Parse(Console.ReadLine());

        double decor = 0.1 * budget;
        if (people > 150) 
            priceClothing -= 0.1 * priceClothing;

        double total = decor + (priceClothing * people);

        if (total > budget)
        {
            Console.WriteLine($"Not enough money!");
            Console.WriteLine($"Wingard needs {total - budget:f2} leva more.");
        }
        else
        {
            Console.WriteLine($"Action!");
            Console.WriteLine($"Wingard starts filming with {budget - total:f2} leva left.");
        }
    }
}
