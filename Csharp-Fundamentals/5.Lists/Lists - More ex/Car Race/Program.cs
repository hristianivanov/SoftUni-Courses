using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> left = nums.Take(nums.Count / 2).ToList();
            List<double> right = nums.Skip(nums.Count / 2 + 1).ToList();

            //double sumLeft = Manipulate(left);
            double sumLeft = 0;
            //double sumRight = Manipulate(right);
            double sumRight = 0;

            List<double> time = nums;
            for (int i = 0; i < time.Count / 2; i++)
            {
                sumLeft += time[i];

                if (time[i] == 0)
                {
                    sumLeft *= 0.8;
                }

            }

            for (int i = time.Count - 1; i > time.Count / 2; i--)
            {
                sumRight += time[i];

                if (time[i] == 0)
                {
                    sumRight *= 0.8;
                }
            }

            if (sumLeft < sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }


        }

        static double Manipulate(List<double> nums)
        {
            double time = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                time += nums[i];
                if (nums[i] == 0)
                {
                    time *= 0.8;
                }
            }

            return time;
        }

    }
}
