using System;

internal class Program
{
    static void Main()
    {
        string showName = Console.ReadLine();
        int episodeLength = int.Parse(Console.ReadLine());
        int breakLength = int.Parse(Console.ReadLine());

        double lunch = breakLength / 8.0;
        double rest = breakLength / 4.0;
        double freeTime = breakLength - lunch - rest;

        if (freeTime >= episodeLength)
            Console.WriteLine($"You have enough time to watch {showName} and left with {Math.Ceiling(freeTime - episodeLength)} minutes free time.");
        else
            Console.WriteLine($"You don't have enough time to watch {showName}, you need {Math.Ceiling(episodeLength - freeTime)} more minutes.");
    }
}
