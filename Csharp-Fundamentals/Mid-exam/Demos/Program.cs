using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            var route = Console.ReadLine().Split("||").ToList();
            int fuel = int.Parse(Console.ReadLine());
            int ammo = int.Parse(Console.ReadLine());

            var commands = new List<string>();

            for (int i = 0; i < route.Count; i++)
            {
                commands.Add(route[i].Split(' ')[0]);
            }

            for (int i = 0; i < route.Count; i++)
            {
                if (route[i].Split(' ')[0] == "Travel")
                {
                    if (fuel - 1 >= 0)
                    {
                        Console.WriteLine($" distance{int.Parse(route[i].Split(' ')[1])} ");
                    }
                    else
                    {
                        Console.WriteLine("mission failed"); return;
                    }
                }
                else if (route[i].Split(' ')[0] == "Enemy")
                {
                    if (ammo >= int.Parse(route[i].Split(' ')[1]))
                    {
                        Console.WriteLine($"An enemy with {int.Parse(route[i].Split(' ')[1])} armour is defeated.");
                    }
                    else 
                    {
                        fuel -= int.Parse(route[i].Split(' ')[1]) * 2;
                        if (fuel>=0)
                        {
                            Console.WriteLine("preminal");
                        }
                        else
                        {
                            Console.WriteLine("failed");
                        }
                    }
                }
                else if (route[i].Split(' ')[0] == "Repair")
                {

                }


            }
        }
    }
}
