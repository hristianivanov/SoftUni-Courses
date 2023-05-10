using System;

public class Program
{
    public static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:f2}", r * r * Math.PI);
        Console.WriteLine("{0:f2}", 2 * r * Math.PI);
    }
}