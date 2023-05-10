using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string highestName = "";
        double highestRating = double.MinValue;
        string lowestName = "";
        double lowestRating = double.MaxValue;
        double sumRating = 0;

        for (int i = 1; i <= n; i++)
        {
            string name = Console.ReadLine();
            double rating = double.Parse(Console.ReadLine());
            if (rating > highestRating)
            {
                highestRating = rating;
                highestName = name;
            }
            if (rating < lowestRating)
            {
                lowestRating = rating;
                lowestName = name;
            }
            sumRating += rating;
        }

        Console.WriteLine($"{highestName} is with highest rating: {highestRating:f1}");
        Console.WriteLine($"{lowestName} is with lowest rating: {lowestRating:f1}");
        Console.WriteLine($"Average rating: {sumRating / n:f1}");
    }
}