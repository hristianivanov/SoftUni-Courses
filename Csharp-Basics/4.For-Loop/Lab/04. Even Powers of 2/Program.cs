using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()); int num = 1;
        for (int i = 0; i <= n; i += 2)
        {
            Console.WriteLine(num);
            num = num * 2 * 2;
        }
    }
}