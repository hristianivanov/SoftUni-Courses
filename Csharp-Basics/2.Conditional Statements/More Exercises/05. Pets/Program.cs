using System;


internal class Program
{
    static void Main(string[] args)
    {
        int days = int.Parse(Console.ReadLine());
        int foodLeft = int.Parse(Console.ReadLine());
        double dogFood = double.Parse(Console.ReadLine());
        double catFood = double.Parse(Console.ReadLine());
        double turtleFood = double.Parse(Console.ReadLine()) / 1000;

        double allFood = (dogFood + catFood + turtleFood) * days;
        allFood = Math.Ceiling(allFood);
        if (foodLeft >= allFood)
            Console.WriteLine($"{foodLeft - allFood} kilos of food left.");
        else
            Console.WriteLine($"{allFood - foodLeft} more kilos of food are needed.");
    }
}