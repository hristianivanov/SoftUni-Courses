using System;

public class Program
{
    public static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double greenArea = 2 * (x * x) + 2 * (x * y) - 6.9;
        double redArea = x * h + 2 * x * y;
        double greenPaint = greenArea / 3.4;
        double redPaint = redArea / 4.3;

        Console.WriteLine("{0:f2}", greenPaint);
        Console.WriteLine("{0:f2}", redPaint);
    }
}