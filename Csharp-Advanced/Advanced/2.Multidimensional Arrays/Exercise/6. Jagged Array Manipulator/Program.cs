using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                jaggedArr[i] = input;
            }
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] /= 2;
                    }
                }  
            }
            var command = Console.ReadLine().Split();

            //"Add {row} {column} {value}" - add { value} to the element at the given indexes, if they are valid
            //"Subtract {row} {column} {value}" - subtract { value} from the element at the given indexes, if they are valid
            //"End" - print the final state of the matrix(all elements separated by a single space) and stop the program

            while (command[0] != "End")
            {
                int rowData = int.Parse(command[1]);
                int colData = int.Parse(command[2]);
                double value = double.Parse(command[3]);
                if (rowData >= 0 && rowData < jaggedArr.Length && colData >= 0 && colData < jaggedArr[rowData].Length)
                {
                    if (command[0] == "Add")
                    {
                        jaggedArr[rowData][colData] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jaggedArr[rowData][colData] -= value;
                    }
                }

                command = Console.ReadLine().Split();
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i]));
            }
        }
    }
}
