using System;

namespace SU_Resource
{
    internal class Program
    {
        static void Main()
        {
            int fee = int.Parse(Console.ReadLine());
            double shoes = fee * 0.6;
            double outfit = shoes * 0.8;
            double ball = outfit / 4;
            double accessories = ball / 5;
            double total = fee + shoes + outfit + ball + accessories;

            Console.WriteLine(total);

        }
    }
}