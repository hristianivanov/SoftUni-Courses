using System;
using System.Linq;

namespace _4.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());

                box.Items.Add(item);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(indexes[0], indexes[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
