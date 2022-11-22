using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> startsWithCapital = w => char.IsUpper(w[0]);

            Console.WriteLine(string.Join(Environment.NewLine, Array
                .FindAll(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                ,startsWithCapital)
                ));
        }
    }
}
