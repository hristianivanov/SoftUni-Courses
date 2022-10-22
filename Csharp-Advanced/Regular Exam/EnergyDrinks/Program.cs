using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //maximum caffeine Stamat can have for the night is 300 milligrams
            //initial is always 0.

            //take the last milligrams of caffeinе and
            //the first energy drink, and multiply them.


            //•	If the sum of the caffeine in the drink and the caffeine that Stamat drank doesn't exceed 300 milligrams,
            //remove both the milligrams of caffeinе and the drink from their sequences.
            //Also, add the caffeine to Stamat's total caffeine.


            //•	If Stamat is about to exceed his maximum caffeine per night, do not add the caffeine
            //to Stamat’s total caffeine. Remove the milligrams of caffeinе and move the drink
            //to the end of the sequence. Also, reduce the current caffeine
            //that Stamat has taken by 30 (Note: Stamat's caffeine cannot go below 0).

            //Stop calculating when you are out of drinks or milligrams of caffeine.




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

                if (total+sum<=MAXIMUM_DRINKING) // = ?
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
