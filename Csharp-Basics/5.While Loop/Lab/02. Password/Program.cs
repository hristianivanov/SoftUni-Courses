using System;

internal class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        string pass = Console.ReadLine();

        string attempt = string.Empty;
        while ((attempt = Console.ReadLine()) != pass) { }
        Console.WriteLine($"Welcome {name}!");
    }
}