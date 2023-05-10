using System;

internal class Program
{
    static void Main()
    {
        double vacationCost = double.Parse(Console.ReadLine());
        double money = double.Parse(Console.ReadLine());
        int spendCount = 0;
        int days = 0;

        while (money < vacationCost && spendCount < 5)
        {
            days++;
            string action = Console.ReadLine();
            double dailyMoney = double.Parse(Console.ReadLine());
            if (action == "save")
            {
                money += dailyMoney;
                spendCount = 0;
            }
            else if (action == "spend")
            {
                money -= dailyMoney;
                spendCount++;
                if (money < 0) money = 0;
            }
        }
        if (spendCount == 5) Console.WriteLine($"You can't save the money.\n{days}");
        else Console.WriteLine($"You saved the money for {days} days.");
    }
}