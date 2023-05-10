using System;

public class Program
{
    static void Main()
    {
        string tName = Console.ReadLine();
        int wins = 0;
        int losses = 0;

        while (tName != "End of tournaments")
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int us = int.Parse(Console.ReadLine());
                int them = int.Parse(Console.ReadLine());
                if (us > them)
                {
                    wins++;
                    Console.WriteLine($"Game {i} of tournament {tName}: win with {us - them} points.");
                }
                if (us < them)
                {
                    losses++;
                    Console.WriteLine($"Game {i} of tournament {tName}: lost with {them - us} points.");
                }
            }
            tName = Console.ReadLine();
        }

        Console.WriteLine($"{wins * 100.0 / (wins + losses):f2}% matches win");
        Console.WriteLine($"{losses * 100.0 / (wins + losses):f2}% matches lost");
    }
}