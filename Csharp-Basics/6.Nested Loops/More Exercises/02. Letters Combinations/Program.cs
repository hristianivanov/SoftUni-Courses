using System;

internal class Program
{
    static void Main(string[] args)
    {
        char lower = char.Parse(Console.ReadLine());
        char higher = char.Parse(Console.ReadLine());
        char exception = char.Parse(Console.ReadLine());
        int count = 0;

        for (char c1 = lower; c1 <= higher; c1++)
        {
            for (char c2 = lower; c2 <= higher; c2++)
            {
                for (char c3 = lower; c3 <= higher; c3++)
                {
                    if (c1 != exception && c2 != exception && c3 != exception)
                    {
                        Console.Write($"{c1}{c2}{c3} ");
                        count++;
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}