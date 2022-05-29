using System;

namespace _09._Padawan_Equipme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	The count of students – integer in the range[0…100]
            //•   The amount of money John has – the floating-point number in the range[0.00…1, 000.00]
            //•	The price of lightsabers for a single saber – the floating - point number in the range[0.00…100.00]
            //•	The price of robes for a single robe – the floating - point number in the range[0.00…100.00]
            //•	The price of belts for a single belt – the floating - point number in the range[0.00…100.00]
            //•   The input data will always be valid.There is no need to check it explicitly.

            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightSaber = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());

            //•	Lightsabres sometimes break, so John should buy 10 % more(taken from the student's count), rounded up to the next integer
            //•	Every sixth belt is free


            double totalPrice = 0;
            int freeBelts = students / 6;
            double students1 = Math.Ceiling((students * 0.1) + students);

            totalPrice = (students1 * lightSaber) + ((students - freeBelts) * belts) + (students * robes);

            if (money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - money:f2}lv more.");
            }

        }
    }
}
