using System;

public class Program
{
    public static void Main()
    {
        double age = double.Parse(Console.ReadLine());
        string gender = Console.ReadLine();

        if (gender == "m")
        {
            if (age >= 16)
                Console.WriteLine("Mr.");
            else
                Console.WriteLine("Master");
        }
        if (gender == "f")
        {
            if (age >= 16)
                Console.WriteLine("Ms.");
            else
                Console.WriteLine("Miss");
        }
    }
}