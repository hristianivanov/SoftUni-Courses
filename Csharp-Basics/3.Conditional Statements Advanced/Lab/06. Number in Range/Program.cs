using System;

public class Program
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool inRange = false;

        if (number >= -100 && number <= 100 && number != 0)
            inRange = true;

        if (inRange)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}