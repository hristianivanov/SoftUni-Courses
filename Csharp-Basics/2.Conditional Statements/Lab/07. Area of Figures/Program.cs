using System;

internal class Program
{
    static void Main()
    {
        string type = Console.ReadLine();
        double area = double.MinValue;
        double x = double.Parse(Console.ReadLine());

        if (type == "square")
            area = x * x;
        else if (type == "rectangle")
        {
            double y = double.Parse(Console.ReadLine());
            area = x * y;
        }
        else if (type == "circle")
            area = Math.PI * x * x;
        else if (type == "triangle")
        {
            double h = double.Parse(Console.ReadLine());
            area = x * h / 2;
        }

        Console.WriteLine($"{area:f3}");
    }
}
