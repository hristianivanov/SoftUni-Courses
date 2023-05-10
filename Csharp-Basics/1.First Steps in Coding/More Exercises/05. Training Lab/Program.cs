using System;

public class Program
{
    public static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double length = double.Parse(Console.ReadLine()) - 1;

        double rows = Math.Floor(width / 1.2);
        double columns = Math.Floor(length / 0.7);
        double totalSeats = rows * columns - 3;

        Console.WriteLine("{0:f0}", totalSeats);
    }
}