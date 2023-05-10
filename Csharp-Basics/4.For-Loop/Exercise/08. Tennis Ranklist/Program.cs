using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int startPoints = int.Parse(Console.ReadLine());
        int score = 0;
        int timesWon = 0;

        for (int i = 1; i <= n; i++)
        {
            string result = Console.ReadLine().ToLower();
            switch (result)
            {
                case "w": score += 2000; timesWon++; break;
                case "f": score += 1200; break;
                case "sf": score += 720; break;
            }
        }

        Console.WriteLine("Final points: {0}", score + startPoints);
        Console.WriteLine("Average points: {0}", score / n);
        Console.WriteLine("{0:f2}%", timesWon * 100.0 / n * 1.0);
    }
}