using System;
using System.Linq;

namespace demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "@I was quick to judge him@ but it wasn't his fault@";
            var output = input.Split().Reverse();
            foreach (var item in output)
            {
                Console.WriteLine(item + " ");
            }
        }
    }
}
