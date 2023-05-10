using System;


internal class Program
{
    static void Main(string[] args)
    {
        int v = int.Parse(Console.ReadLine());
        int p1 = int.Parse(Console.ReadLine());
        int p2 = int.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double pipe1 = p1 * h;
        double pipe2 = p2 * h;
        double allWater = pipe1 + pipe2;
        if (allWater <= v)
            Console.WriteLine($"The pool is {allWater * 100 / v:f2}% full. Pipe 1: {pipe1 * 100 / allWater:f2}%. Pipe 2: {pipe2 * 100 / allWater:f2}%.");
        else
            Console.WriteLine($"For {h} hours the pool overflows with {allWater - v:f2} liters.");
    }
}