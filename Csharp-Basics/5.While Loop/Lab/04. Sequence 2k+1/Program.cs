using System;

internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()), num = 1;

        while (num <= n)
        {
            Console.WriteLine(num);
            num = num * 2 + 1;
        }
    }
}