using System;

public class Program
{
    public static void Main()
    {
        int amount1 = int.Parse(Console.ReadLine());
        int amount2 = int.Parse(Console.ReadLine());
        int amount5 = int.Parse(Console.ReadLine());
        int sum = int.Parse(Console.ReadLine());

        for (int count1 = 0; count1 <= amount1; count1++)
        {
            for (int count2 = 0; count2 <= amount2; count2++)
            {
                for (int count5 = 0; count5 <= amount5; count5++)
                {
                    if (count1 * 1 + count2 * 2 + count5 * 5 == sum)
                    {
                        Console.WriteLine("{0} * 1 lv. + {1} * 2 lv. + {2} * 5 lv. = {3} lv.", count1, count2, count5, sum);
                    }
                }
            }
        }
    }
}