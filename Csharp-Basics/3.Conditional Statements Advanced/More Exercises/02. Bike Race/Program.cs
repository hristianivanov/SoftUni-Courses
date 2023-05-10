using System;

internal class Program
{
    static void Main(string[] args)
    {
        int juniors = int.Parse(Console.ReadLine());
        int seniors = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        bool haveDiscount = type == "cross-country" && juniors + seniors >= 50;
        double total = 0;

        switch (type)
        {
            case "trail": total = juniors * 5.50 + seniors * 7.00; break;
            case "cross-country": total = juniors * 8.00 + seniors * 9.50; break;
            case "downhill": total = juniors * 12.25 + seniors * 13.75; break;
            case "road": total = juniors * 20.00 + seniors * 21.50; break;
        }
        if (haveDiscount)
            total *= 0.75;
        total *= 0.95;

        Console.WriteLine($"{total:f2}");
    }
}