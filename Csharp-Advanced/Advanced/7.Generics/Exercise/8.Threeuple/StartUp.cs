using System;

namespace _8.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            string[] secondLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] thirdLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> nameAdress = new Threeuple<string, string, string>()
            {
                FirstItem = $"{firstLine[0]} {firstLine[1]}",
                SecondItem = firstLine[2],
                ThirdItem = firstLine.Length > 4 ? $"{firstLine[3]} {firstLine[4]}" : firstLine[3]
            };
            Threeuple<string, int, bool> nameBeer = new Threeuple<string, int, bool>()
            {
                FirstItem = secondLine[0],
                SecondItem = int.Parse(secondLine[1]),
                ThirdItem = secondLine[2] == "drunk",
            };
            Threeuple<string, double, string> bankAcc = new Threeuple<string, double, string>()
            {
                FirstItem = thirdLine[0],
                SecondItem = double.Parse(thirdLine[1]),
                ThirdItem = thirdLine[2],
            };

            Console.WriteLine(nameAdress);
            Console.WriteLine(nameBeer);
            Console.WriteLine(bankAcc);
        }
    }
}
