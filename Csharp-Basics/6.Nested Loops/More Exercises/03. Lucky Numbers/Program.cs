using System;

internal class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        for (int n1 = 1; n1 <= 9; n1++)
        {
            for (int n2 = 1; n2 <= 9; n2++)
            {
                for (int n3 = 1; n3 <= 9; n3++)
                {
                    for (int n4 = 1; n4 <= 9; n4++)
                    {
                        if (n1 + n2 == n3 + n4 && number % (n1 + n2) == 0)
                            Console.Write($"{n1}{n2}{n3}{n4} ");
                    }
                }
            }
        }
    }
}