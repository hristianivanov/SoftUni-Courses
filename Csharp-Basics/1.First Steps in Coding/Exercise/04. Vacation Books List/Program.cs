using System;

namespace SU_Resource
{
    internal class Program
    {
        static void Main()
        {
            int pagesInBook = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int pagesPerDay = pagesInBook / days;
            int hoursPerDay = pagesPerDay / pagesPerHour;

            Console.WriteLine(hoursPerDay);
        }
    }
}