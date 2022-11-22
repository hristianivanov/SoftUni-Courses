using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[n][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                jaggedArr[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] cmdArgs = command.Split();
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row>=0 && row<jaggedArr.Length && col>=0 && col < jaggedArr[row].Length)
                {
                    if (cmdArgs[0] == "add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else
                    {
                        jaggedArr[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                command = Console.ReadLine().ToLower();
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
