using System;

namespace _7.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split();

            string[] secondLine = Console.ReadLine()
                .Split();

            string[] thirdLine = Console.ReadLine()
                .Split();


            Tuple<string, string> nameAddres = new Tuple<string, string>()
            {
                FirstItem = firstLine[0] + " " + firstLine[1],
                SecondItem = firstLine[2]
            };
            Tuple<string, int> nameBeer = new Tuple<string, int>()
            {
                FirstItem = secondLine[0],
                SecondItem = int.Parse(secondLine[1])
            };
            Tuple<int, double> nums = new Tuple<int, double>()
            {
                FirstItem = int.Parse(thirdLine[0]),
                SecondItem = double.Parse(thirdLine[1])
            };

            Console.WriteLine(nameAddres);
            Console.WriteLine(nameBeer);
            Console.WriteLine(nums);
        }
    }
}


