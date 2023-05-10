using System;

internal class Program
{
    static void Main(string[] args)
    {
        int firstTop = int.Parse(Console.ReadLine());
        int secondTop = int.Parse(Console.ReadLine());
        int thirdTop = int.Parse(Console.ReadLine());
        for (int n1 = 1; n1 <= firstTop; n1++)
        {
            for (int n2 = 1; n2 <= secondTop; n2++)
            {
                for (int n3 = 1; n3 <= thirdTop; n3++)
                {
                    if (n1 % 2 == 0 && n3 % 2 == 0)
                        switch (n2)
                        {
                            case 2:
                            case 3:
                            case 5:
                            case 7:
                                Console.WriteLine($"{n1} {n2} {n3}");
                                break;
                        }
                }

            }
        }
    }
}