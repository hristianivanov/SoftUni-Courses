using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TilesMaster
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greys = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> locationsList = new Dictionary<string, int>()
            {
                {"Sink", 40},
                {"Oven", 50},
                {"Countertop", 60},
                {"Wall", 70}
            };

            Dictionary<string, int> tilesCount = new Dictionary<string, int>()
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor",0 }
            };

            while (whites.Count != 0 && greys.Count != 0)
            {
                int currWhite = whites.Peek();
                int currGrey = greys.Peek();
                if (currWhite == currGrey)
                {
                    string condition = Check(currWhite + currGrey);

                    switch (condition)
                    {
                        case "Sink":
                        case "Oven":
                        case "Countertop":
                        case "Wall":
                        case "Floor":
                            tilesCount[condition]++;
                            Remove(whites, greys);
                            break;
                    }
                }
                else
                {
                    whites.Push(whites.Pop() / 2);

                    greys.Enqueue(greys.Dequeue());
                }
            }

            string whiteTilesLeft = whites.Count == 0 ? "none" : string.Join(", ", whites);
            string greyTilesLeft = greys.Count == 0 ? "none" : string.Join(", ", greys);


            Console.WriteLine($"White tiles left: {whiteTilesLeft}");
            Console.WriteLine($"Grey tiles left: {greyTilesLeft}");

            tilesCount = tilesCount
                .Where(x=>x.Value>0)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in tilesCount)
            {
                    Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }

        private static void Remove(Stack<int> white, Queue<int> grey)
        {
            white.Pop(); grey.Dequeue();
        }

        private static string Check(int sum)
        {
            switch (sum)
            {
                case 40: return "Sink";
                case 50: return "Oven";
                case 60: return "Countertop";
                case 70: return "Wall";
                default:
                    return "Floor";
                    break;
            }
        }
    }
}
