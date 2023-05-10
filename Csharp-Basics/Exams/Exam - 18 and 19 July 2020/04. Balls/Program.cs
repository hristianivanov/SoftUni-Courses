using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int points = 0;
        int red = 0;
        int orange = 0;
        int yellow = 0;
        int white = 0;
        int black = 0;
        int other = 0;

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "red": points += 5; red++; break;
                case "orange": points += 10; orange++; break;
                case "yellow": points += 15; yellow++; break;
                case "white": points += 20; white++; break;
                case "black": points /= 2; black++; break;
                default: other++; break;
            }
        }
        Console.WriteLine($"Total points: {points}");
        Console.WriteLine($"Red balls: {red}");
        Console.WriteLine($"Orange balls: {orange}");
        Console.WriteLine($"Yellow balls: {yellow}");
        Console.WriteLine($"White balls: {white}");
        Console.WriteLine($"Other colors picked: {other}");
        Console.WriteLine($"Divides from black balls: {black}");
    }
}