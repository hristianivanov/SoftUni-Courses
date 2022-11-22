using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split();

            int n = int.Parse(cmdArgs[0]);
            int s = int.Parse(cmdArgs[1]);
            int x = int.Parse(cmdArgs[2]);

            //N representing the number of elements to push into the stack
            //S representing the number of elements to pop from the stack
            //X representing an element that you should look for in the stack.

            //If it's found, print "true" on the console.
            //If it isn't, print the smallest element currently present in the stack.If there are no elements in the sequence, print 0 on the console.

            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(nums);

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Any() ? stack.Min() : 0);
            }
        }


    }
}
