using System;

public class Program
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        if (!(num >= 100 && num <= 200 || num == 0))
            Console.WriteLine("invalid");
    }
}