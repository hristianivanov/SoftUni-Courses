using System;

internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sugarTotal = 0;
        int flourTotal = 0;
        int sugarMax = 0;
        int flourMax = 0;

        for (int i = 1; i <= n; i++)
        {
            int sugar = int.Parse(Console.ReadLine());
            int flour = int.Parse(Console.ReadLine());
            sugarTotal += sugar;
            flourTotal += flour;
            sugarMax = Math.Max(sugar, sugarMax);
            flourMax = Math.Max(flour, flourMax);
        }

        int sugarPacks = sugarTotal / 950;
        if (sugarTotal % 950 != 0) sugarPacks++;
        int flourPacks = flourTotal / 750;
        if (flourTotal % 750 != 0) flourPacks++;

        Console.WriteLine($"Sugar: {sugarPacks}");
        Console.WriteLine($"Flour: {flourPacks}");
        Console.WriteLine($"Max used flour is {flourMax} grams, max used sugar is {sugarMax} grams.");
    }
}