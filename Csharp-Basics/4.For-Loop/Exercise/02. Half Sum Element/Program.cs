using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int max = int.MinValue, sum = 0;
        for (int i = 1; i <= n; i++)
        {
            int newNumber = int.Parse(Console.ReadLine());
            sum += newNumber;
            max = Math.Max(newNumber, max);
        }
        if (max == sum - max)
            Console.WriteLine("Yes\nSum = {0}", max);
        else
            Console.WriteLine("No\nDiff = {0}", Math.Abs(max - (sum - max)));
    }
}