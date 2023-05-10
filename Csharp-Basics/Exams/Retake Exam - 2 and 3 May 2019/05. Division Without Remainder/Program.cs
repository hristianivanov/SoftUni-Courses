using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p2 = 0;
        int p3 = 0;
        int p4 = 0;

        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0) p2++;
            if (num % 3 == 0) p3++;
            if (num % 4 == 0) p4++;
        }

        Console.WriteLine($"{(double)p2 * 100 / n:f2}%");
        Console.WriteLine($"{(double)p3 * 100 / n:f2}%");
        Console.WriteLine($"{(double)p4 * 100 / n:f2}%");
    }
}