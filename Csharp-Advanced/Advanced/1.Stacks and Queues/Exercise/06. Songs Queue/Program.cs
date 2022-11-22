using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(input);

            var cmdArgs = Console.ReadLine();

            while (songs.Count > 0)
            {
                string command = cmdArgs
                    .Split(' ')
                    .ToArray()
                    .FirstOrDefault();

                var song = cmdArgs.Substring(cmdArgs.IndexOf(' ') + 1);

                if (command == "Add")
                {
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                cmdArgs = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
