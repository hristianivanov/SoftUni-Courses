using System;

public class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        int people = int.Parse(Console.ReadLine());
        double clothing = people * double.Parse(Console.ReadLine());
        double decor = 0.1 * budget;
        if (people > 150) clothing -= 0.1 * clothing;

        double total = clothing + decor;
        if (total > budget)
        {
            Console.WriteLine($"Not enough money!");
            Console.WriteLine($"Wingard needs {total - budget:f2} leva more.");
        }
        else
        {
            Console.WriteLine("Action!");
            Console.WriteLine($"Wingard starts filming with {budget - total:f2} leva left.");
        }
    }
}