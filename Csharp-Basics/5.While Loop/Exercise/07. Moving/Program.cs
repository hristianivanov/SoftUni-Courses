using System;

internal class Program
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int z = int.Parse(Console.ReadLine());
        int space = x * y * z;

        while (true)
        {
            if (space < 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(space)} Cubic meters more.");
                break;
            }
            string input = Console.ReadLine();
            if (input == "Done")
            {
                Console.WriteLine($"{space} Cubic meters left.");
                break;
            }
            int boxes = int.Parse(input);
            space -= boxes;
        }
    }
}