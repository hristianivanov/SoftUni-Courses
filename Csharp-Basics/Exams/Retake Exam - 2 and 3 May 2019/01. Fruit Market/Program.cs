using System;

public class Program
{
    public static void Main()
    {
        double strawberryPrice = double.Parse(Console.ReadLine());
        double bananaKg = double.Parse(Console.ReadLine());
        double orangeKg = double.Parse(Console.ReadLine());
        double raspberryKg = double.Parse(Console.ReadLine());
        double strawberryKg = double.Parse(Console.ReadLine());

        double raspberryPrice = 0.5 * strawberryPrice;
        double orangePrice = 0.6 * raspberryPrice;
        double bananaPrice = 0.2 * raspberryPrice;

        double total = strawberryPrice * strawberryKg + bananaPrice * bananaKg + orangePrice * orangeKg + raspberryPrice * raspberryKg;
        Console.WriteLine("{0:f2}", total);
    }
}