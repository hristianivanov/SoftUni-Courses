using System;

public class Program
{
    public static void Main()
    {
        int wins = 0;
        int losses = 0;
        int draws = 0;

        for (int i = 1; i <= 3; i++)
        {
            string input = Console.ReadLine();
            int we = int.Parse(input[0].ToString());
            int they = int.Parse(input[2].ToString());
            if (we > they) wins++;
            else if (we == they) draws++;
            else if (we < they) losses++;
        }
        Console.WriteLine("Team won {0} games.", wins);
        Console.WriteLine("Team lost {0} games.", losses);
        Console.WriteLine("Drawn games: {0}", draws);
    }
}