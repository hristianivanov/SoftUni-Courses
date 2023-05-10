using System;

internal class Program
{
    static void Main(string[] args)
    {
        double magnolia = double.Parse(Console.ReadLine()) * 3.25;
        double zumbul = double.Parse(Console.ReadLine()) * 4.00;
        double rose = double.Parse(Console.ReadLine()) * 3.50;
        double cactus = double.Parse(Console.ReadLine()) * 8.00;
        double presentPrice = double.Parse(Console.ReadLine());

        double earnings = magnolia + zumbul + rose + cactus;
        earnings *= 0.95;
        if (earnings >= presentPrice)
            Console.WriteLine($"She is left with {Math.Floor(earnings - presentPrice)} leva.");
        else
            Console.WriteLine($"She will have to borrow {Math.Ceiling(presentPrice - earnings)} leva.");
    }
}