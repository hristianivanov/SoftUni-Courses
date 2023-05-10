using System;

internal class Program
{
    static void Main(string[] args)
    {
        int bestGoals = -1;
        string bestPlayer = "";

        string input = Console.ReadLine();
        while (input != "END")
        {
            int goals = int.Parse(Console.ReadLine());
            if (goals > bestGoals)
            {
                bestGoals = goals;
                bestPlayer = input;
            }
            if (goals >= 10) break;
            input = Console.ReadLine();
        }
        Console.WriteLine($"{bestPlayer} is the best player!");
        if (bestGoals >= 3) Console.WriteLine($"He has scored {bestGoals} goals and made a hat-trick !!!");
        else Console.WriteLine($"He has scored {bestGoals} goals.");
    }
}