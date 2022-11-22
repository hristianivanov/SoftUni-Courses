using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BakeryShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));


            Dictionary<string, int> waterRatio = new Dictionary<string, int>()
            {
                {"Croissant",50 },
                {"Muffin",40 },
                {"Baguette",30 },
                {"Bagel",20 },
            };

            Dictionary<string, int> counter = new Dictionary<string, int>()
            {
                {"Croissant",0 },
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 },
            };
            while (flour.Count != 0 && water.Count != 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                double waterPercentige = currWater * 100 / (currWater + currFlour);
                switch (waterPercentige)
                {
                    case 50:
                        counter["Croissant"]++; break;
                    case 40:
                        counter["Muffin"]++; break;
                    case 30:
                        counter["Baguette"]++; break;
                    case 20:
                        counter["Bagel"]++; break;
                    default:
                        counter["Croissant"]++;
                        flour.Push(Math.Abs(currFlour - currWater));
                        break;
                }
            }
            string leftWater = water.Count == 0 ? "None" : string.Join(", ", water);
            string leftFlour = flour.Count == 0 ? "None" : string.Join(", ", flour);

            foreach (var item in counter.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine($"Water left: {leftWater}");
            Console.WriteLine($"Flour left: {leftFlour}");

        }
    }
}
