using System;

internal class Program
{
    static void Main()
    {
        int steps = 0;
        bool goingHome = false;

        while (steps < 10000)
        {
            if (goingHome) { steps += int.Parse(Console.ReadLine()); break; }
            string input = Console.ReadLine();
            if (input == "Going home") goingHome = true;
            else steps += int.Parse(input);
        }
        if (steps >= 10000)
        {
            Console.WriteLine($"Goal reached! Good job!");
            Console.WriteLine($"{steps - 10000} steps over the goal!");
        }
        else Console.WriteLine($"{10000 - steps} more steps to reach goal.");
    }
}