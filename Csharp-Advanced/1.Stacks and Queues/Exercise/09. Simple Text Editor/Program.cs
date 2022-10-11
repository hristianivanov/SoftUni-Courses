using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> states = new Stack<string>();

            states.Push(string.Empty);

            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string input = Console.ReadLine();

                string command = input.Split().First();
                string item = input.Split().Last();

                switch (command)
                {
                    case "1":
                        states.Push(states.Peek() + item);
                        break;
                    case "2":
                        int count = int.Parse(item);
                        string newState = states.Peek().Remove(states.Peek().Length - count);
                        states.Push(newState);
                        break;
                    case "3":
                        int index = int.Parse(item) - 1;
                        Console.WriteLine(states.Peek()[index]);
                        break;
                    case "4":
                        states.Pop();
                        break;
                }
            }
        }
    }
}
