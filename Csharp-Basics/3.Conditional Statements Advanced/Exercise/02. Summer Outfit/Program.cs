using System;

public class Program
{
    public static void Main()
    {
        int degrees = int.Parse(Console.ReadLine());
        string time = Console.ReadLine();
        string outfit = "Shirt";
        string shoes = "Moccasins";

        if (degrees >= 10 && degrees <= 18)
        {
            if (time == "Morning")
                outfit = "Sweatshirt"; shoes = "Sneakers";
        }

        if (degrees > 18 && degrees <= 24)
        {
            if (time == "Afternoon")
                outfit = "T-Shirt"; shoes = "Sandals";
        }
        if (degrees >= 25)
        {
            if (time == "Morning")
                outfit = "T-Shirt"; shoes = "Sandals";
            else if (time == "Afternoon")
                outfit = "Swim Suit"; shoes = "Barefoot";
        }
        Console.WriteLine("It's {0} degrees, get your {1} and {2}.", degrees, outfit, shoes);
    }
}