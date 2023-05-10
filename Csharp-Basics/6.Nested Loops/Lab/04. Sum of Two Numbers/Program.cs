using System;

internal class Program
{
    static void Main()
    {
        int low = int.Parse(Console.ReadLine());
        int high = int.Parse(Console.ReadLine());
        int magic = int.Parse(Console.ReadLine());
        int comboNumber = 0;
        bool isFound = false;

        for (int i = low; i <= high; i++)
        {
            for (int j = low; j <= high; j++)
            {
                comboNumber++;
                if (i + j == magic)
                {
                    isFound = true;
                    low = i;
                    high = j;
                    break;
                }
            }
            if (isFound) break;
        }
        if (!isFound) 
            Console.WriteLine($"{comboNumber} combinations - neither equals {magic}");
        else
            Console.WriteLine($"Combination N:{comboNumber} ({low} + {high} = {magic})");
    }
}