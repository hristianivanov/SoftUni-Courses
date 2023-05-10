using System;

internal class Program
{
    static void Main()
    {
        int min = int.MaxValue, num;
        string input;

        while (true)
        {
            input = Console.ReadLine();
            if (input == "Stop")
                break;

            num = int.Parse(input);
            min = Math.Min(min, num);
        }
        Console.WriteLine(min);
    }
}