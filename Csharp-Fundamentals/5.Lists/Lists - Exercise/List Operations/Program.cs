using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        {
                            int number = int.Parse(tokens[1]);
                            numbers.Add(number);
                            break;
                        }
                    case "Insert":
                        {
                            int number = int.Parse(tokens[1]);
                            int index = int.Parse(tokens[2]);

                            if (index < 0 || index >= numbers.Count)
                            {
                                Console.WriteLine("Invalid index");
                            }
                            else
                            {
                                numbers.Insert(index, number);
                            }
                            break;
                        }
                    case "Remove":
                        {
                            int index = int.Parse(tokens[1]);

                            if (index < 0 || index >= numbers.Count)
                            {
                                Console.WriteLine("Invalid index");
                            }
                            else
                            {
                                numbers.RemoveAt(index);
                            }
                            break;
                        }
                    case "Shift":
                        {
                            int count = int.Parse(tokens[2]);
                            numbers = ShiftList(numbers, count, tokens[1]);
                            break;
                        }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> ShiftList(List<int> list, int count, string direction)
        {
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int temp = list[0];

                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        list[j] = list[j + 1];
                    }

                    list[list.Count - 1] = temp;
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < count; i++)
                {
                    int temp = list[list.Count - 1];

                    for (int j = list.Count - 1; j > 0; j--)
                    {
                        list[j] = list[j - 1];
                    }

                    list[0] = temp;
                }
            }

            return list;
        }
    }
}
