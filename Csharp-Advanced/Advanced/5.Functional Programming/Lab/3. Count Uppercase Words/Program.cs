using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Predicate<string> startsWithCapital = w => char.IsUpper(w[0]);
            Dictionary<string,int> kvp = new Dictionary<string,int>();
            kvp.Add("pesho", 1);
            kvp["pesho"]++;
            kvp.Add("gosho", 6);

            kvp.OrderBy(x => x.Value);
            Console.WriteLine(string.Join(" ",kvp.Values));
            //Console.WriteLine(string.Join(Environment.NewLine, Array
            //    .FindAll(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
            //    ,startsWithCapital)
            //    ));
        }
    }
}
