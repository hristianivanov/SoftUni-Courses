using System;

public class Program
{
    public static void Main()
    {
        string name = Console.ReadLine();
        string input = Console.ReadLine();
        int totalPoints = 301;
        int successfulShots = 0;
        int unsuccessfulShots = 0;
        bool gameWon = false;

        while (input != "Retire")
        {
            int points = int.Parse(Console.ReadLine());
            if (input == "Double") points *= 2;
            else if (input == "Triple") points *= 3;

            if (points > totalPoints) unsuccessfulShots++;
            else if (points < totalPoints) { totalPoints -= points; successfulShots++; }
            else
            {
                gameWon = true;
                successfulShots++;
                Console.WriteLine("{0} won the leg with {1} shots.", name, successfulShots);
                break;
            }
            input = Console.ReadLine();
        }
        if (!gameWon) Console.WriteLine("{0} retired after {1} unsuccessful shots.", name, unsuccessfulShots);
    }
}