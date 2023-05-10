using System;

public class Program
{
    public static void Main()
    {
        double detergent = double.Parse(Console.ReadLine()) * 750;
        int dishes = 0;
        int pots = 0;
        int counter = 1;

        string input = Console.ReadLine();
        while (input != "End")
        {
            int num = int.Parse(input);
            if (counter % 3 == 0)
                pots += num; detergent -= num * 15;
            else
                dishes += num; detergent -= num * 5;
            counter++;
            if (detergent < 0)
                Console.WriteLine("Not enough detergent, {0} ml. more necessary!", Math.Abs(detergent)); return;
            input = Console.ReadLine();
        }
        Console.WriteLine("Detergent was enough!");
        Console.WriteLine("{0} dishes and {1} pots were washed.", dishes, pots);
        Console.WriteLine("Leftover detergent {0} ml.", detergent);
    }
}