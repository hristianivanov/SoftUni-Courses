using System;

internal class Program
{
    static void Main()
    {
        double record = double.Parse(Console.ReadLine());
        double distance = double.Parse(Console.ReadLine());
        double secondsPerMeter = double.Parse(Console.ReadLine());

        double total = distance * secondsPerMeter;
        double delay = Math.Floor(distance / 15) * 12.5;
        total += delay;

        if (total >= record)
            Console.WriteLine($"No, he failed! He was {total - record:f2} seconds slower.");
        else
            Console.WriteLine($"Yes, he succeeded! The new world record is {total:f2} seconds.");
    }
}