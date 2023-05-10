using System;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()), sum = 0;
        for (int i = 0; i < n; i++)
            sum += int.Parse(Console.ReadLine());
        Console.WriteLine("{0:f2}", (double)sum / n);
    }
}