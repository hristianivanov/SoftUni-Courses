using System;

public class Program
{
    public static void Main()
    {
        int minutes = int.Parse(Console.ReadLine());
        int walks = int.Parse(Console.ReadLine());
        int totalCalories = int.Parse(Console.ReadLine());

        int spentCalories = minutes * walks * 5;
        if (spentCalories * 2 >= totalCalories)
            Console.WriteLine("Yes, the walk for your cat is enough. Burned calories per day: {0}.", spentCalories);
        else
            Console.WriteLine("No, the walk for your cat is not enough. Burned calories per day: {0}.", spentCalories);
    }
}