using System;

public class Program
{
    public static void Main()
    {
        int hour = int.Parse(Console.ReadLine());
        string day = Console.ReadLine();

        if (hour >= 10 && hour <= 18 && day != "Sunday")
            Console.WriteLine("open");
        else
            Console.WriteLine("closed");
    }
}