using System;

public class Program
{
    public static void Main()
    {
        double profit = double.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        double total = 0;

        while (input != "Party!")
        {
            int quantity = int.Parse(Console.ReadLine());
            int price = input.Length;
            double cost = quantity * price;
            if ((quantity * price) % 2 == 1) cost *= 0.75;
            total += cost;
            if (total >= profit) break;
            input = Console.ReadLine();
        }

        if (total >= profit) Console.WriteLine("Target acquired.");
        else Console.WriteLine("We need {0:f2} leva more.", profit - total);
        Console.WriteLine("Club income - {0:f2} leva.", total);
    }
}