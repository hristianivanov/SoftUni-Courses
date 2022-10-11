using System;

namespace The_hunting_games
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double totalWater = waterPerDay * players * days;
            double totalFood = foodPerDay * players * days;

            int secondDay = 0;
            int thirdDay = 0;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupsEnergy -= energyLoss;

                if (groupsEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    groupsEnergy += groupsEnergy * 0.05;
                    totalWater -= totalWater * 0.30;
                }
                if (i % 3 == 0)
                {
                    groupsEnergy += groupsEnergy * 0.10;
                    totalFood -= totalFood / players;
                }

            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:f2} energy!");

        }

    }
}
