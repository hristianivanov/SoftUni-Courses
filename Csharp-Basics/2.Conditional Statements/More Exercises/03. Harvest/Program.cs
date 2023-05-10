using System;

internal class Program
{
    static void Main(string[] args)
    {
        int vineArea = int.Parse(Console.ReadLine());
        double grapesPerSqM = double.Parse(Console.ReadLine());
        int wineNeeded = int.Parse(Console.ReadLine());
        int workers = int.Parse(Console.ReadLine());

        double harvest = 0.4 * vineArea;
        double grapes = harvest * grapesPerSqM;
        double wine = grapes / 2.5;

        if (wine < wineNeeded)
            Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineNeeded - wine)} liters wine needed.");
        else
        {
            Console.WriteLine($"Good harvest this year! Total wine: {wine} liters.");
            Console.WriteLine($"{Math.Ceiling(wine - wineNeeded)} liters left -> {Math.Ceiling((wine - wineNeeded) / workers)} liters per person.");
        }
    }
}