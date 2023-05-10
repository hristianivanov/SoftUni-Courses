using System;

public class Program
{
    public static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Stop")
            Console.WriteLine(input);
    }
}