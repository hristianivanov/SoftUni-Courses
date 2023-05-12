using System;
using System.Linq;

namespace Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int input = 23;
            bool isDigit = int.TryParse(input.ToString(),out int digit); // checks is it integer and return it what u want
            Console.WriteLine(digit);  // out : 23
            
        }
    }
}
