using System;

namespace Presentation
{
    internal class Program
    {
        static void Main()
        {
            double area = double.Parse(Console.ReadLine());
            double totalCost = area * 7.61;
            double discount = totalCost * 0.18;
            double endPrice = totalCost - discount;

            Console.WriteLine($"The final price is: {endPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
