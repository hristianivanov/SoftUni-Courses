using System;
using System.Collections.Generic;

namespace _6._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
