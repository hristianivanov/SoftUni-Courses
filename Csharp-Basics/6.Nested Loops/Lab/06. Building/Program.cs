using System;

internal class Program
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int rooms = int.Parse(Console.ReadLine());

        if (floors > 0)
            for (int i = 0; i < rooms; i++)
                Console.Write($"L{floors}{i} ");

        Console.WriteLine(); floors--;

        for (int i = floors; i > 0; i--)
        {
            for (int j = 0; j < rooms; j++)
            {
                if (i % 2 == 0) 
                    Console.Write($"O{i}{j} ");
                else
                    Console.Write($"A{i}{j} ");
            }
            Console.WriteLine();
        }


    }
}