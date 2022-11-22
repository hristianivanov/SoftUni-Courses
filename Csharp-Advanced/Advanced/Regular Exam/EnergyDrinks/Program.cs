using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAXIMUM_DRINKING = 300;
            
            Stack<int> caffeinе = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int sum = 0;
            int total = 0;
            while (energyDrinks.Any() && caffeinе.Any())
            {
                int currCaffeine = caffeinе.Pop();
                int currDrink = energyDrinks.Dequeue();

                sum = currCaffeine * currDrink;

                if (total+sum<=MAXIMUM_DRINKING)
                {
                    total += sum;
                }
                else if (total+sum>MAXIMUM_DRINKING)
                {
                    energyDrinks.Enqueue(currDrink);
                    if (total-30>=0)
                    {
                        total -= 30;
                    }
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ",energyDrinks)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {total} mg caffeine.");
        }
    }
}
