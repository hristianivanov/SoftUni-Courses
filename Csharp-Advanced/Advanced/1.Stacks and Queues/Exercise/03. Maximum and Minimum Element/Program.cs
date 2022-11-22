using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                .Split();

                var cmdType = cmdArgs[0];
                if (cmdType == "1")
                {
                    int num = int.Parse(cmdArgs[1]);
                    nums.Push(num);
                }
                else if (cmdType == "2")
                {
                    if (nums.Any())
                    {
                        nums.Pop();
                        continue;
                    }
                }
                else if (cmdType == "3")
                {
                    if (nums.Any())
                    {
                        Console.WriteLine(nums.Max());
                    }
                }
                else if (cmdType == "4")
                {
                    if (nums.Any())
                    {
                        Console.WriteLine(nums.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
