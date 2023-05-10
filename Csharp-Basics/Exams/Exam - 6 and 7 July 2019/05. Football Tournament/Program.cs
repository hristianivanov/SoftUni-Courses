using System;

public class Program
{
    public static void Main()
    {
        string name = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        int wins = 0;
        int draws = 0;
        int losses = 0;

        for (int i = 1; i <= n; i++)
        {
            string outcome = Console.ReadLine();
            if (outcome == "W") wins++;
            else if (outcome == "L") losses++;
            else draws++;
        }
        int result = wins * 3 + draws;

        if (n < 1) Console.WriteLine("{0} hasn't played any games during this season.", name);
        else
        {
            Console.WriteLine("{0} has won {1} points during this season.", name, result);
            Console.WriteLine("Total stats:");
            Console.WriteLine("## W: {0}", wins);
            Console.WriteLine("## D: {0}", draws);
            Console.WriteLine("## L: {0}", losses);
            Console.WriteLine("Win rate: {0:f2}%", wins * 100.0 / n);
        }
    }
}