using System;

namespace SU_Resource
{
    public class Program
    {
        static void Main()
        {
            string country = Console.ReadLine();
            string tool = Console.ReadLine();
            double score = 0;

            switch (country)
            {
                case "Russia":
                    if (tool == "ribbon") score = 9.1 + 9.4;
                    if (tool == "hoop") score = 9.3 + 9.8;
                    if (tool == "rope") score = 9.6 + 9.0;
                    break;
                case "Bulgaria":
                    if (tool == "ribbon") score = 9.6 + 9.4;
                    if (tool == "hoop") score = 9.55 + 9.75;
                    if (tool == "rope") score = 9.5 + 9.4;
                    break;
                case "Italy":
                    if (tool == "ribbon") score = 9.2 + 9.5;
                    if (tool == "hoop") score = 9.45 + 9.35;
                    if (tool == "rope") score = 9.7 + 9.15;
                    break;
            }
            Console.WriteLine($"The team of {country} get {score:f3} on {tool}.");
            Console.WriteLine($"{((20 - score) / 20 * 100):f2}%");
        }
    }
}