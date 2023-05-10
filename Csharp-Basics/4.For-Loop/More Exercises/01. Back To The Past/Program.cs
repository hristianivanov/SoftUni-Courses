using System;

internal class Program
{
    static void Main(string[] args)
    {
        double money = double.Parse(Console.ReadLine());
        int yearMax = int.Parse(Console.ReadLine());
        int age = 17;

        for (int year = 1800; year <= yearMax; year++)
        {
            age++;
            if (year % 2 == 0)
                money -= 12000;
            else
                money -= 12000 + 50 * age;
        }
        if (money >= 0)
            Console.WriteLine($"Yes! He will live a carefree life and will have {money:f2} dollars left.");
        else
            Console.WriteLine($"He will need {Math.Abs(money):f2} dollars to survive.");
    }
}