using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static Stack<int> bullets = new Stack<int>();
        static Queue<int> locks = new Queue<int>();
        static Queue<int> barrel = new Queue<int>();
        static int barrelSize = 0;

        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            barrelSize = int.Parse(Console.ReadLine());
            LoadInitialBulletsAndLocks();
            Reload();
            int moneyEarned = int.Parse(Console.ReadLine());

            while (barrel.Count > 0 && locks.Count > 0)
            {
                moneyEarned -= bulletPrice;
                int bulletShot = barrel.Dequeue();
                if (bulletShot <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (barrel.Count == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    Reload();
                }
            }

            if (locks.Count == 0)
                Console.WriteLine($"{bullets.Count + barrel.Count} bullets left. Earned ${moneyEarned}");
            else
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }

        private static void LoadInitialBulletsAndLocks()
        {
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int bullet in bulletsInput)
                bullets.Push(bullet);

            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int singleLock in locksInput)
                locks.Enqueue(singleLock);
        }

        private static void Reload()
        {
            for (int i = 0; i < barrelSize; i++)
            {
                if (bullets.Count > 0)
                    barrel.Enqueue(bullets.Pop());
            }
        }
    }
}
