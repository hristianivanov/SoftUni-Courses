using System;

internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;
        for (int i = 1; i <= n; i++)
        {
            count++;
            int num = int.Parse(Console.ReadLine());

            if (num < 200)
                p1++;
            else if (num < 400)
                p2++;
            else if (num < 600)
                p3++;
            else if (num < 800)
                p4++;
            else
                p5++;
        }
        Console.WriteLine("{0:f2}%", p1 * 100.0 / count);
        Console.WriteLine("{0:f2}%", p2 * 100.0 / count);
        Console.WriteLine("{0:f2}%", p3 * 100.0 / count);
        Console.WriteLine("{0:f2}%", p4 * 100.0 / count);
        Console.WriteLine("{0:f2}%", p5 * 100.0 / count);
    }
}