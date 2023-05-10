using System;

public class Program
{
    static void Main()
    {
        int rent = int.Parse(Console.ReadLine());
        double prizes = 0.7 * rent;
        double catering = 0.85 * prizes;
        double sound = 0.5 * catering;

        double total = rent + prizes + catering + sound;
        Console.WriteLine($"{total:f2}");
    }
}