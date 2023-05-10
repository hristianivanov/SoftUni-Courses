using System;

internal class Program
{
    static void Main()
    {
        int limit = int.Parse(Console.ReadLine()), sum = 0, newNum = 0;

        while (sum < limit)
        {
            newNum = int.Parse(Console.ReadLine());
            sum += newNum;
        }
        Console.WriteLine(sum);
    }
}