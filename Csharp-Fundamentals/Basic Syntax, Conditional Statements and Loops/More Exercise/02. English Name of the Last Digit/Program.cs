using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Text;

namespace _02._English_Name_of_the_Last_Digit

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = number % 10 == 1 ? "one" :
                number % 10 == 2 ? "two" :
                number % 10 == 3 ? "three" :
                number % 10 == 4 ? "four" :
                number % 10 == 5 ? "five" :
                number % 10 == 6 ? "six" :
                number % 10 == 7 ? "seven" :
                number % 10 == 8 ? "eight" :
                number % 10 == 9 ? "nine" : "zero";

            Console.WriteLine(result);
        }
    }
}
