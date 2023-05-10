using System;

internal class Program
{
    static void Main()
    {
        int turns = int.Parse(Console.ReadLine());
        int zero = 0, one = 0, two = 0, three = 0, four = 0, invalid = 0;
        double result = 0;

        for (int i = 0; i < turns; i++)
        {
            int num = int.Parse(Console.ReadLine());

            if (num >= 0 && num <= 9)
                zero++; result += 0.2 * num;
            else if (num >= 10 && num <= 19)
                one++; result += 0.3 * num;
            else if (num >= 20 && num <= 29)
                two++; result += 0.4 * num;
            else if (num >= 30 && num <= 39)
                three++; result += 50;
            else if (num >= 40 && num <= 50)
                four++; result += 100;
            else
                result /= 2; invalid++;
        }

        Console.WriteLine($"{result:f2}");
        Console.WriteLine($"From 0 to 9: {zero * 100.0 / turns:f2}%");
        Console.WriteLine($"From 10 to 19: {one * 100.0 / turns:f2}%");
        Console.WriteLine($"From 20 to 29: {two * 100.0 / turns:f2}%");
        Console.WriteLine($"From 30 to 39: {three * 100.0 / turns:f2}%");
        Console.WriteLine($"From 40 to 50: {four * 100.0 / turns:f2}%");
        Console.WriteLine($"Invalid numbers: {invalid * 100.0 / turns:f2}%");
    }
}