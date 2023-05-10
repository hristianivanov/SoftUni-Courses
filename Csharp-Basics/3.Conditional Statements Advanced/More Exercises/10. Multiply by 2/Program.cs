using System;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            double num = double.Parse(Console.ReadLine());
            if (num < 0)
                Console.WriteLine("Negative number!"); break;
            else
                Console.WriteLine("Result: {0:f2}", num * 2);
        }
    }
}