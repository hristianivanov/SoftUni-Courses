using System;

public class Program
{
    static void Main()
    {
        string companyName = Console.ReadLine();
        int adultAmount = int.Parse(Console.ReadLine());
        int kidAmount = int.Parse(Console.ReadLine());
        double adultPrice = double.Parse(Console.ReadLine());
        double kidPrice = 0.3 * adultPrice;
        double fee = double.Parse(Console.ReadLine());

        adultPrice += fee;
        kidPrice += fee;

        double total = adultPrice * adultAmount + kidPrice * kidAmount;
        total *= 0.2;

        Console.WriteLine($"The profit of your agency from {companyName} tickets is {total:f2} lv.");
    }
}