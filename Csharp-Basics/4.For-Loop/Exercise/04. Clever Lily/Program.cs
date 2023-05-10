using System;

internal class Program
{
    static void Main()
    {
        int age = int.Parse(Console.ReadLine());
        double washingPrice = double.Parse(Console.ReadLine());
        int toyPrice = int.Parse(Console.ReadLine());
        int toys = 0;
        double money = 0;

        for (int i = 1; i <= age; i++)
        {
            if (i % 2 == 1)
                toys++;
            else
                money += i * 5.0 - 1.0;
        }
        money += toys * toyPrice;

        if (money >= washingPrice)
            Console.WriteLine("Yes! {0:f2}", money - washingPrice);
        else
            Console.WriteLine("No! {0:f2}", washingPrice - money);

    }
}