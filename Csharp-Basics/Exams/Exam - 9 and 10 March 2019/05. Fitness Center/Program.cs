using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int back = 0;
        int chest = 0;
        int legs = 0;
        int abs = 0;
        int shake = 0;
        int bar = 0;

        for (int i = 1; i <= n; i++)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "Back": back++; break;
                case "Chest": chest++; break;
                case "Legs": legs++; break;
                case "Abs": abs++; break;
                case "Protein shake": shake++; break;
                case "Protein bar": bar++; break;
            }
        }
        Console.WriteLine($"{back} - back");
        Console.WriteLine($"{chest} - chest");
        Console.WriteLine($"{legs} - legs");
        Console.WriteLine($"{abs} - abs");
        Console.WriteLine($"{shake} - protein shake");
        Console.WriteLine($"{bar} - protein bar");
        Console.WriteLine($"{(back + chest + legs + abs) * 100.0 / n:f2}% - work out");
        Console.WriteLine($"{(shake + bar) * 100.0 / n:f2}% - protein");
    }
}