using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "register":
                        if (parking.ContainsKey(input[1]))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {input[2]}");
                        }
                        else
                        {
                            Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                            parking.Add(input[1], input[2]);
                        }
                        break;
                    case "unregister":
                        if (parking.ContainsKey(input[1]))
                        {
                            Console.WriteLine($"{input[1]} unregistered successfully");
                            parking.Remove(input[1]);
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {input[1]} not found");
                        }
                        break;
                    default:
                        break;
                }
                
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }
    }
}
