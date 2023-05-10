using System;

internal class Program
{
    static void Main()
    {
        int firstMax = int.Parse(Console.ReadLine());
        int secondMax = int.Parse(Console.ReadLine());
        int thirdMax = int.Parse(Console.ReadLine());

        for (int first = 1; first <= firstMax; first++)
        {
            for (int second = 1; second <= secondMax; second++)
            {
                for (int third = 1; third <= thirdMax; third++)
                {
                    if (first % 2 == 0 && third % 2 == 0)
                        switch (second)
                        {
                            case 2:
                            case 3:
                            case 5:
                            case 7:
                                Console.WriteLine($"{first} {second} {third}");
                                break;
                        }

                }
            }
        }
    }
}