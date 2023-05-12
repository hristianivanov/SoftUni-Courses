using System;
using System.Linq;

namespace Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int tempEl = arr[0];
                for (int operations = 0; operations < arr.Length - 1; operations++)
                {
                    arr[operations] = arr[operations + 1];
                }

                arr[arr.Length - 1] = tempEl;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
