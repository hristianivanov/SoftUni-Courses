using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var input = Console.ReadLine().Split();
            while (input[0]!="Finish")
            {
                if (input[0]=="Add")
                {
                    nums.Add(int.Parse(input[1]));
                }
                else if (input[0]=="Remove")
                {
                    nums.Remove(int.Parse(input[1]));
                }
                else if (input[0]=="Replace")
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] == int.Parse(input[1]))
                        {
                            nums[i] = int.Parse(input[2]);
                            break;
                        }
                    }
                }
                else if (input[0]=="Collapse")
                {
                    nums.RemoveAll(x => x < int.Parse(input[1]));
                }

                input = Console.ReadLine().Split();
            }
            foreach (var item in nums)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
