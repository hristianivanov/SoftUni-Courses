using System;

public class Program
{
    public static void Main()
    {
        string destination = Console.ReadLine();
        string dates = Console.ReadLine();
        int nights = int.Parse(Console.ReadLine());
        int total = 0;
        int cost = 0;

        switch (destination)
        {
            case "France":
                if (dates == "21-23") cost = 30;
                else if (dates == "24-27") cost = 35;
                else if (dates == "28-31") cost = 40;
                break;
            case "Italy":
                if (dates == "21-23") cost = 28;
                else if (dates == "24-27") cost = 32;
                else if (dates == "28-31") cost = 39;
                break;
            case "Germany":
                if (dates == "21-23") cost = 32;
                else if (dates == "24-27") cost = 37;
                else if (dates == "28-31") cost = 43;
                break;
        }
        total = nights * cost;

        Console.WriteLine("Easter trip to {0} : {1:f2} leva.", destination, total);
    }
}