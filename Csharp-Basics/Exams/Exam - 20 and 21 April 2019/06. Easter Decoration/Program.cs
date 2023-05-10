using System;

internal class Program
{
    static void Main()
    {
        int clients = int.Parse(Console.ReadLine());
        double totalAllclients = 0;

        for (int i = 1; i <= clients; i++)
        {
            double totalThisClient = 0;
            int itemsCount = 0;
            string input = Console.ReadLine();
            while (input != "Finish")
            {
                switch (input)
                {
                    case "basket": totalThisClient += 1.50; break;
                    case "wreath": totalThisClient += 3.80; break;
                    case "chocolate bunny": totalThisClient += 7.00; break;
                }
                itemsCount++;
                input = Console.ReadLine();
            }
            if (itemsCount % 2 == 0) totalThisClient -= totalThisClient * 0.2;
            Console.WriteLine($"You purchased {itemsCount} items for {totalThisClient:f2} leva.");
            totalAllclients += totalThisClient;
        }
        Console.WriteLine($"Average bill per client is: {(totalAllclients / clients):f2} leva.");
    }
}