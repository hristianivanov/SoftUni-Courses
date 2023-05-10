using System;

public class Program
{
    public static void Main()
    {
        int control = int.Parse(Console.ReadLine());
        int counter = 0;
        int password = 0;

        for (int a = 1; a <= 9; a++)
            for (int b = 1; b <= 9; b++)
                for (int c = 1; c <= 9; c++)
                    for (int d = 1; d <= 9; d++)
                    {
                        if (a * b + c * d == control && a < b && c > d)
                        {
                            Console.Write("{0}{1}{2}{3} ", a, b, c, d);
                            counter++;
                            if (counter == 4) password = 1000 * a + 100 * b + 10 * c + d;
                        }
                    }
        Console.WriteLine();
        if (password == 0) Console.WriteLine("No!");
        else Console.WriteLine("Password: {0}", password);
    }
}