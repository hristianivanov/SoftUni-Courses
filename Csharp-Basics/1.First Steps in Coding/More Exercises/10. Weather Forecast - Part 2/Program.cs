using System;

public class Program
{
    public static void Main()
    {
        double input = double.Parse(Console.ReadLine());
        if (input < 5 || input > 35)
            Console.WriteLine("unknown");
        else if (input >= 5 && input < 12)
            Console.WriteLine("Cold");
        else if (input < 15)
            Console.WriteLine("Cool");
        else if (input <= 20)
            Console.WriteLine("Mild");
        else if (input < 26)
            Console.WriteLine("Warm");
        else if (input <= 35)
            Console.WriteLine("Hot");
    }
}