using System;


internal class Program
{
    static void Main(string[] args)
    {
        int holidays = int.Parse(Console.ReadLine());
        int workdays = 365 - holidays;
        int TomPlay = holidays * 127 + workdays * 63;

        if (TomPlay > 30000)
        {
            int diff = TomPlay - 30000;
            Console.WriteLine("Tom will run away");
            Console.WriteLine($"{diff / 60} hours and {diff % 60} minutes more for play");
        }
        else
        {
            int diff = 30000 - TomPlay;
            Console.WriteLine("Tom sleeps well");
            Console.WriteLine($"{diff / 60} hours and {diff % 60} minutes less for play");
        }
    }
}