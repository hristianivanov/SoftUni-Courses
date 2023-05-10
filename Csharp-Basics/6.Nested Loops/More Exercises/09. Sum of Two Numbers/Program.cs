using System;

internal class Program
{
    static void Main()
    {
        int begin = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int magic = int.Parse(Console.ReadLine());
        int combination = 0;

        for (int i = begin; i <= end; i++)
        {
            for (int j = begin; j <= end; j++)
            {
                combination++;
                if (i + j == magic)
                {
                    Console.WriteLine($"Combination N:{combination} ({i} + {j} = {magic})");
                    return;
                }
            }
        }
        Console.WriteLine($"{combination} combinations - neither equals {magic}");
    }
}