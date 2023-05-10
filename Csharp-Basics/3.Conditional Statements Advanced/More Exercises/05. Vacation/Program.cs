using System;

internal class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        bool isSummer = Console.ReadLine() == "Summer";
        string housing = "Hotel";
        string location = "Morocco";
        double cost;

        if (isSummer)
            location = "Alaska";
        if (budget <= 1000)
        {
            housing = "Camp";
            if (isSummer)
                cost = 0.65 * budget;
            else
                cost = 0.45 * budget;
        }
        else if (budget <= 3000)
        {
            housing = "Hut";
            if (isSummer)
                cost = 0.80 * budget;
            else
                cost = 0.60 * budget;
        }
        else
            cost = 0.90 * budget;

        Console.WriteLine($"{location} - {housing} - {cost:f2}");
    }
}