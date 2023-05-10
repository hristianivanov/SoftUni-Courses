using System;

internal class Program
{
    static void Main(string[] args)
    {
        int men = int.Parse(Console.ReadLine());
        int women = int.Parse(Console.ReadLine());
        int tables = int.Parse(Console.ReadLine());

        for (int m = 1; m <= men; m++)
        {
            for (int w = 1; w <= women; w++)
            {
                Console.Write($"({m} <-> {w}) ");
                tables--;
                if (tables == 0)
                    return;
            }
        }
    }
}