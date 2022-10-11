using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 1; j < tokens.Length; j++)
                {
                    string currentClothing = tokens[j];

                    if (!wardrobe[color].ContainsKey(currentClothing))
                    {
                        wardrobe[color].Add(currentClothing, 0);
                    }

                    wardrobe[color][currentClothing]++;
                }
            }

            string[] findParams = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var clothByColor in wardrobe)
            {
                Console.WriteLine($"{clothByColor.Key} clothes:");

                foreach (var cloth in clothByColor.Value)
                {
                    string printItem = $"* {cloth.Key} - {cloth.Value}";

                    if (clothByColor.Key == findParams[0] && cloth.Key == findParams[1])
                    {
                        printItem += " (found!)";
                    }

                    Console.WriteLine(printItem);
                }
            }
        }
    }
}
