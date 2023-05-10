using System;


internal class Program
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int pieces = x * y;

        while (pieces > 0 || input == "STOP")
        {
            string input = Console.ReadLine();
            int piecesTaken = int.Parse(input);
            pieces -= piecesTaken;
        }
        if (pieces >= 0) 
            Console.WriteLine($"{pieces} pieces are left.");
        else 
            Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
    }
}