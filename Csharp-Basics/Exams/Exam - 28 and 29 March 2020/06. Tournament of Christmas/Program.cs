using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double totalMoney = 0;
        int dayScore = 0;

        for (int i = 1; i <= n; i++)
        {
            double dailyMoney = 0;
            int gameScore = 0;
            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string outcome = Console.ReadLine();
                if (outcome == "win")
                {
                    dailyMoney += 20;
                    gameScore++;
                }
                else gameScore--;

                input = Console.ReadLine();
            }

            if (gameScore > 0) { dailyMoney *= 1.1; dayScore++; }
            else dayScore--;
            totalMoney += dailyMoney;
        }

        if (dayScore > 0)
        {
            totalMoney *= 1.2;
            Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
        }
        else Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
    }
}