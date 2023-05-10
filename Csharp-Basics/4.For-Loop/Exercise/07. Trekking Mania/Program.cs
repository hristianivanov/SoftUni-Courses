using System;

internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int total = 0, musala = 0, monblan = 0, everest = 0, kilim = 0, k2 = 0;

        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());

            if (num <= 5)
                musala += num;
            else if (num <= 12)
                monblan += num;
            else if (num <= 25)
                kilim += num;
            else if (num <= 40)
                k2 += num;
            else
                everest += num;
            total += num;
        }

        Console.WriteLine("{0:f2}%", musala * 100.0 / total);
        Console.WriteLine("{0:f2}%", monblan * 100.0 / total);
        Console.WriteLine("{0:f2}%", kilim * 100.0 / total);
        Console.WriteLine("{0:f2}%", k2 * 100.0 / total);
        Console.WriteLine("{0:f2}%", everest * 100.0 / total);
    }
}