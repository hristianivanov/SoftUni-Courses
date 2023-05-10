using System;

internal class Program
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine().ToLower();
        double liters = double.Parse(Console.ReadLine());
        if (type != "gas" && type != "gasoline" && type != "diesel")
            Console.WriteLine("Invalid fuel!");
        else
        {
            if (liters >= 25)
                Console.WriteLine($"You have enough {type}.");
            else
                Console.WriteLine($"Fill your tank with {type}!");
        }
    }
}