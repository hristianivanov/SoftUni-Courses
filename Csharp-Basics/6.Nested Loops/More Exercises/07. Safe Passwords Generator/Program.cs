using System;

internal class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int pass = int.Parse(Console.ReadLine());
        char A = Convert.ToChar(35);
        char B = Convert.ToChar(64);

        for (int x = 1; x <= a; x++)
        {
            for (int y = 1; y <= b; y++)
            {
                Console.Write($"{A}{B}{x}{y}{B}{A}|");
                A++; B++;
                if (A > 55) A = Convert.ToChar(35);
                if (B > 96) B = Convert.ToChar(64);
                pass--;
                if (pass == 0) return;
            }
        }

    }
}