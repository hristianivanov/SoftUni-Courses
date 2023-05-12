using System;

namespace _09._Padawan_Equipme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightSaber = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());

            double totalPrice = 0;
            int freeBelts = students / 6;
            double students1 = Math.Ceiling((students * 0.1) + students);

            totalPrice = (students1 * lightSaber) + ((students - freeBelts) * belts) + (students * robes);

            if (money >= totalPrice)
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            else
                Console.WriteLine($"John will need {totalPrice - money:f2}lv more.");
        }
    }
}
