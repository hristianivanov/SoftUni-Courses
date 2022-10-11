using System;
using System.Collections.Generic;

namespace _7._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            var names = new Queue<string>();
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (names.Count != 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                    names.Enqueue(input);
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
