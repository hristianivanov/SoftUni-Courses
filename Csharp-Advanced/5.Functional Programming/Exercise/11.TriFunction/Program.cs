using System;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkEqualOrLargerNameSum = (name, num) =>
              name.Sum(ch => ch) >= num;

            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, num, match) =>
                names.FirstOrDefault(name => match(name, num));

            int num = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(getFirstName(names, num, checkEqualOrLargerNameSum));
           // Console.WriteLine(names.FirstOrDefault(name => name.Sum(ch=>ch) >= num));
        }
    }
}
