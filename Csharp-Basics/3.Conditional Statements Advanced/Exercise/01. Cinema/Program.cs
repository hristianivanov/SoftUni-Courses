using System;

public class Program
{
    public static void Main()
    {
        string type = Console.ReadLine();
        int c = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());

        double sales = r * c;
        if (type == "Premiere")
            sales *= 12.00;
        else if (type == "Normal")
            sales *= 7.50;
        else if (type == "Discount")
            sales *= 5.00;

        Console.WriteLine("{0:f2} leva", sales);
    }
}