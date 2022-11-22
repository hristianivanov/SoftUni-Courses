using System;
using System.Linq;

namespace _3.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();

                box.Items.Add(item);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(indexes[0], indexes[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
