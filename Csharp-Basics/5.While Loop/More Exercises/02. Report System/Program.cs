using System;

public class Program
{
    public static void Main()
    {
        int target = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int cash = 0;
        int card = 0;
        int counter = 1;
        int cashCount = 0;
        int cardCount = 0;

        while (input != "End")
        {
            int num = int.Parse(input);
            if (counter % 2 == 0)
            {
                if (num < 10) Console.WriteLine("Error in transaction!");
                else { Console.WriteLine("Product sold!"); card += num; cardCount++; }
            }
            else
            {
                if (num > 100) Console.WriteLine("Error in transaction!");
                else { Console.WriteLine("Product sold!"); cash += num; cashCount++; }
            }
            if (cash + card >= target)
            {
                Console.WriteLine("Average CS: {0:f2}", (double)cash / (double)cashCount);
                Console.WriteLine("Average CC: {0:f2}", (double)card / (double)cardCount);
                return;
            }
            counter++;
            input = Console.ReadLine();
        }
        Console.WriteLine("Failed to collect required money for charity.");
    }
}