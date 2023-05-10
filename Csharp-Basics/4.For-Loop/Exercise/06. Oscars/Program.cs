using System;

internal class Program
{
    static void Main()
    {
        string actor = Console.ReadLine();
        double score = double.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n && score < 1250.5; i++)
        {
            string judge = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            score += judge.Length * grade * 1.0 / 2.0;
        }
        if (score > 1250.5)
            Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {score:f1}!");
        else
            Console.WriteLine($"Sorry, {actor} you need {(1250.5 - score):f1} more!");
    }
}