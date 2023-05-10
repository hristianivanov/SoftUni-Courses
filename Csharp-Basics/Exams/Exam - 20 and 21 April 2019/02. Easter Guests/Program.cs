using System;

public class Program
{
    public static void Main()
    {
        int guests = int.Parse(Console.ReadLine());
        int budget = int.Parse(Console.ReadLine());

        int breadcount = guests / 3;
        if (guests % 3 != 0) breadcount++;
        int eggcount = guests * 2;
        double total = breadcount * 4.00 + eggcount * 0.45;

        if (budget >= total)
        {
            Console.WriteLine("Lyubo bought {0} Easter bread and {1} eggs.", breadcount, eggcount);
            Console.WriteLine("He has {0:f2} lv. left.", budget - total);
        }
        else
        {
            Console.WriteLine("Lyubo doesn't have enough money.");
            Console.WriteLine("He needs {0:f2} lv. more.", total - budget);
        }
    }
}