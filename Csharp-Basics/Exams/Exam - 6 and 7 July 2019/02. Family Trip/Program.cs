using System;

public class Program
{
    public static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        int nights = int.Parse(Console.ReadLine());
        double nightPrice = double.Parse(Console.ReadLine());
        double additional = double.Parse(Console.ReadLine()) / 100 * budget;

        if (nights > 7) nightPrice *= 0.95;
        double total = nights * nightPrice + additional;
        if (budget >= total) Console.WriteLine("Ivanovi will be left with {0:f2} leva after vacation.", budget - total);
        else Console.WriteLine("{0:f2} leva needed.", total - budget);
    }
}