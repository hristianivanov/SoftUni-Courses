using System;

public class Program
{
    public static void Main()
    {
        string fruit = Console.ReadLine();
        string day = Console.ReadLine();
        double quantity = double.Parse(Console.ReadLine());
        double price = 0.0;
        double total = 0.0;
        bool valid = true;

        switch (day)
        {
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
                switch (fruit)
                {
                    case "banana": price = 2.50; break;
                    case "apple": price = 1.20; break;
                    case "orange": price = 0.85; break;
                    case "grapefruit": price = 1.45; break;
                    case "kiwi": price = 2.70; break;
                    case "pineapple": price = 5.50; break;
                    case "grapes": price = 3.85; break;
                    default: valid = false; break;
                }
                break;
            case "Saturday":
            case "Sunday":
                switch (fruit)
                {
                    case "banana": price = 2.70; break;
                    case "apple": price = 1.25; break;
                    case "orange": price = 0.90; break;
                    case "grapefruit": price = 1.60; break;
                    case "kiwi": price = 3.00; break;
                    case "pineapple": price = 5.60; break;
                    case "grapes": price = 4.20; break;
                    default: valid = false; break;
                }
                break;
            default: valid = false; break;
        }

        total = price * quantity;
        if (valid)
            Console.WriteLine("{0:f2}", total);
        else
            Console.WriteLine("error");

    }
}
