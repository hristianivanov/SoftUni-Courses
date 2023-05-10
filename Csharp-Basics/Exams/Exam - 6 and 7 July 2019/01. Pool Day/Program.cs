using System;

public class Program
{
    public static void Main()
    {
        int people = int.Parse(Console.ReadLine());
        double entryFee = double.Parse(Console.ReadLine());
        double chairPrice = double.Parse(Console.ReadLine());
        double umbrellaPrice = double.Parse(Console.ReadLine());

        double umbrellaQty = Math.Ceiling(people / 2.0);
        double chairQty = Math.Ceiling(0.75 * people);

        double total = people * entryFee + umbrellaQty * umbrellaPrice + chairQty * chairPrice;
        Console.WriteLine("{0:f2} lv.", total);
    }
}