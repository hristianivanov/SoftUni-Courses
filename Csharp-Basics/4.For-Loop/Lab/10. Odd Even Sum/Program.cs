using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int even = 0, odd = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
                even += int.Parse(Console.ReadLine());
            else
                odd += int.Parse(Console.ReadLine());
        }
        if (even == odd)
            Console.WriteLine("Yes\nSum = {0}", even);
        else
            Console.WriteLine("No\nDiff = {0}", Math.Abs(even - odd));
    }
}