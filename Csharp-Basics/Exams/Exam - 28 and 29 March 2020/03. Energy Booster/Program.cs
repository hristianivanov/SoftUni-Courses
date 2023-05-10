using System;

namespace SU_Resource
{
    public class Program
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            string set = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (set == "small") price = 56.00;
                    else price = 28.70;
                    break;
                case "Mango":
                    if (set == "small") price = 36.66;
                    else price = 19.60;
                    break;
                case "Pineapple":
                    if (set == "small") price = 42.10;
                    else price = 24.80;
                    break;
                case "Raspberry":
                    if (set == "small") price = 20.00;
                    else price = 15.20;
                    break;
            }
            if (set == "small") price *= 2;
            else price *= 5;

            double total = price * quantity;

            if (total > 1000) total -= 0.5 * total;
            else if (total >= 400) total -= 0.15 * total;

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}