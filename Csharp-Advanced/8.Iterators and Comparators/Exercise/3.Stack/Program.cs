using System;
using System.Linq;

namespace _3.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Pop":
                        Pop(stack);
                        break;
                    default:
                        Push(stack, command);
                        break;
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

        }

        private static void Pop(Stack<string> stack)
        {
            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Push(Stack<string> stack, string command)
        {
            string[] input = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
        }
    }
}

