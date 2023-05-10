using System;

public class Program
{
    public static void Main()
    {
        double midiPrice = 7.50;
        double skumriaPrice = double.Parse(Console.ReadLine());
        double cacaPrice = double.Parse(Console.ReadLine());
        double palamudKg = double.Parse(Console.ReadLine());
        double safridKg = double.Parse(Console.ReadLine());
        double midiKg = double.Parse(Console.ReadLine());
        double palamudPrice = 1.6 * skumriaPrice;
        double safridPrice = 1.8 * cacaPrice;

        double total = palamudPrice * palamudKg + safridPrice * safridKg + midiPrice * midiKg;
        Console.WriteLine("{0:f2}", total);
    }
}