using System;

internal class Program
{
    static void Main(string[] args)
    {
        double vegPrice = double.Parse(Console.ReadLine());
        double fruitPrice = double.Parse(Console.ReadLine());
        int vegKg = int.Parse(Console.ReadLine());
        int fruitKg = int.Parse(Console.ReadLine());

        double totalLeva = vegKg * vegPrice + fruitKg * fruitPrice;
        double totalEuro = totalLeva / 1.94;
        Console.WriteLine($"{totalEuro:f2}");
    }
}