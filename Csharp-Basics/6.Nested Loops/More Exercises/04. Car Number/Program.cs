using System;

internal class Program
{
    static void Main(string[] args)
    {
        int lower = int.Parse(Console.ReadLine());
        int higher = int.Parse(Console.ReadLine());

        for (int n1 = lower; n1 <= higher; n1++)
        {
            for (int n2 = lower; n2 <= higher; n2++)
            {
                for (int n3 = lower; n3 <= higher; n3++)
                {
                    for (int n4 = lower; n4 <= higher; n4++)
                    {
                        bool condition1 = (n1 % 2 == 0 && n4 % 2 != 0) || (n1 % 2 != 0 && n4 % 2 == 0);
                        bool condition2 = n1 > n4;
                        bool condition3 = (n2 + n3) % 2 == 0;
                        if (condition1 && condition2 && condition3)
                            Console.Write($"{n1}{n2}{n3}{n4} ");
                    }
                }
            }
        }
    }
}