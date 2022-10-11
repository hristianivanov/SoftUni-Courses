using System;
using System.Collections.Generic;

namespace _6._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> equasion = new Stack<string>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                equasion.Push(input[i]);
            }

            int result = 0;
            bool operatorPlus = true;
            while (equasion.Count != 0)
            {
                string item = equasion.Pop();

                if (item == "+")
                    operatorPlus = true;
                else if (item == "-")
                    operatorPlus = false;
                else if (operatorPlus)
                    result += int.Parse(item);
                else if (!operatorPlus)
                    result -= int.Parse(item);
            }
            Console.WriteLine(result);
        }
    }
}
