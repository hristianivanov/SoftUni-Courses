using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Phone_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phones = Console.ReadLine().Split(", ").ToList();
            var input = Console.ReadLine().Split(" - ").ToList();
            while (input[0] != "End")
            {
                if (input[0] == "Add" && !phones.Contains(input[1]))
                {
                    phones.Add(input[1]);
                }
                else if (input[0] == "Remove")
                {
                    if (phones.Contains(input[1]))
                    {
                        phones.Remove(input[1]);
                    }
                }
                else if (input[0] == "Bonus phone")
                {
                    var info = input[1].Split(":").ToList();
                    if (phones.Contains(info[0]))
                    {
                        phones.Insert(phones.IndexOf(info[0]) + 1, info[1]);
                    }
                }
                else if (input[0] == "Last")
                {
                    if (phones.Contains(input[1]))
                    {
                        phones.Remove(input[1]);
                        phones.Add(input[1]);
                    }
                }


                input = Console.ReadLine().Split(" - ").ToList();
            }


            for (int i = 0; i < phones.Count; i++)
            {
                if (i+1==phones.Count)
                {
                    Console.Write($"{phones[i]}");
                    return;
                }
                else
                {
                    Console.Write($"{phones[i]}, ");
                }
            }
        }

    }
}
