using System;

public class Program
{
    public static void Main()
    {
        int bitcoinQty = int.Parse(Console.ReadLine());
        double yuanQty = double.Parse(Console.ReadLine());
        double comission = double.Parse(Console.ReadLine()) / 100;

        double euro;
        euro = (bitcoinQty * 1168 / 1.95) + (yuanQty * 0.15 * 1.76 / 1.95);
        euro -= comission * euro;
        Console.WriteLine("{0:f2}", euro);
    }
}