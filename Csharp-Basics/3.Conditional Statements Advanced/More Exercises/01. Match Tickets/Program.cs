using System;

internal class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        bool isVip = Console.ReadLine() == "VIP";
        int people = int.Parse(Console.ReadLine());
        double ticketsCost = 0;

        if (isVip)
            ticketsCost = people * 499.99;
        else
            ticketsCost = people * 249.99;

        if (people <= 4)
            budget *= 0.25;
        else if (people <= 9)
            budget *= 0.40;
        else if (people <= 24)
            budget *= 0.50;
        else if (people <= 49)
            budget *= 0.60;
        else budget *= 0.75;

        if (budget >= ticketsCost)
            Console.WriteLine($"Yes! You have {budget - ticketsCost:f2} leva left.");
        else
            Console.WriteLine($"Not enough money! You need {ticketsCost - budget:f2} leva.");
    }
}