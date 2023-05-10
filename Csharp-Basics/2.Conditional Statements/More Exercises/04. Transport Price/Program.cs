using System;

internal class Program
{
    static void Main(string[] args)
    {
        int distance = int.Parse(Console.ReadLine());
        string daynight = Console.ReadLine();
        double total;

        if (distance >= 100)
            total = distance * 0.06;
        else if (distance >= 20)
            total = distance * 0.09;
        else
        {
            total = 0.70;
            if (daynight == "day") total += distance * 0.79;
            else total += distance * 0.90;
        }
        Console.WriteLine($"{total:f2}");
    }
}