using System;

namespace _11._Orders
{
    internal class Program
    {
        public static double OrderPrice(double pricePerCapsule, int days, int capsules)
        {
            return pricePerCapsule * days * capsules;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsules = int.Parse(Console.ReadLine());
                Console.WriteLine($"The price for the coffee is: ${OrderPrice(pricePerCapsule, days, capsules):f2}");
                sum += OrderPrice(pricePerCapsule, days, capsules);
            }
            Console.WriteLine($"Total: ${sum:f2}");
        }
    }
}
