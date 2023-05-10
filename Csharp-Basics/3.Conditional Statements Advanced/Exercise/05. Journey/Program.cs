using System;

internal class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        double total = 0;
        string destination = "";
        string housing = "";

        if (budget <= 100)
        {
            destination = "Bulgaria";
            switch (season)
            {
                case "summer": total = 0.3 * budget; housing = "Camp"; break;
                case "winter": total = 0.7 * budget; housing = "Hotel"; break;
            }
        }
        else if (budget <= 1000)
        {
            destination = "Balkans";
            switch (season)
            {
                case "summer": total = 0.4 * budget; housing = "Camp"; break;
                case "winter": total = 0.8 * budget; housing = "Hotel"; break;
            }
        }
        else
        {
            destination = "Europe";
            total = 0.9 * budget;
            housing = "Hotel";
        }
        Console.WriteLine("Somewhere in {0}", destination);
        Console.WriteLine("{0} - {1:f2}", housing, total);
    }
}
