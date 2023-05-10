using System;

internal class Program
{
    static void Main()
    {
        string input;
        double total = 0;

        while (true)
        {
            double deposit;
            input = Console.ReadLine();

            if (input == "NoMoreMoney") 
                break;
            else 
                deposit = double.Parse(input);
            if (deposit < 0)
                Console.WriteLine("Invalid operation!"); break;

            Console.WriteLine($"Increase: {deposit:F2}");
            total += deposit;
        }
        Console.WriteLine($"Total: {total:F2}");
    }
}