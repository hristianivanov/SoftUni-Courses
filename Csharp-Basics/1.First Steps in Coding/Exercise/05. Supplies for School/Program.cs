using System;

namespace SU_Resource
{
    internal class Program
    {
        static void Main()
        {
            int pensAmount = int.Parse(Console.ReadLine());
            int markersAmount = int.Parse(Console.ReadLine());
            int cleanerAmount = int.Parse(Console.ReadLine());
            double discountPercentage = double.Parse(Console.ReadLine()) / 100.00;

            double penPrice = 5.80;
            double markerPrice = 7.20;
            double cleanerPrice = 1.20;

            double pensCost = pensAmount * penPrice;
            double markersCost = markersAmount * markerPrice;
            double cleanerCost = cleanerAmount * cleanerPrice;

            double allCost = pensCost + markersCost + cleanerCost;
            double discount = allCost * discountPercentage;

            Console.WriteLine(allCost - discount);

        }
    }
}