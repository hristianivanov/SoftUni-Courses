using System;

public class Program
{
    public static void Main()
    {
        int annualFee = int.Parse(Console.ReadLine());
        double shoes = 0.60 * annualFee;
        double outfit = 0.80 * shoes;
        double ball = outfit / 4;
        double accessories = ball / 5;

        double total = shoes + outfit + ball + accessories + annualFee;
        Console.WriteLine("{0:f2}", total);
    }
}