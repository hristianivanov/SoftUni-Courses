using System;

internal class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        double totalGrade = 0;
        int year = 1;
        int fails = 0;

        while (true)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade < 4.00)
            {
                if (fails == 1)
                {
                    Console.WriteLine($"{name} has been excluded at {year} grade");
                    break;
                }
                fails++;
            }
            else
            {
                totalGrade += grade;
                year++;
            }
            if (year > 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {(totalGrade / 12):F2}");
                break;
            }
        }

    }
}