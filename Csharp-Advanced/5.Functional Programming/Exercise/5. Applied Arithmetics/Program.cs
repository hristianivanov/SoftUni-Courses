using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //•	"add"->add 1 to each number
            //•	"multiply"->multiply each number by 2
            //•	"subtract"->subtract 1 from each number
            //•	"print"->print the collection
            //•	"end"->ends the input

            Func<int[], int[]> add = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = nums => nums.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = nums => nums.Select(x => x - 1).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "add": nums = add(nums); break;
                    case "multiply": nums = multiply(nums); break;
                    case "subtract": nums = subtract(nums); break;
                    case "print": print(nums); break;
                    case "end": return; break;

                    default:
                        break;
                }
            }

        }
    }
}
