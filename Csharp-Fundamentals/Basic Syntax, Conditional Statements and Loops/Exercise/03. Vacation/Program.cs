using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();
            double sum = 0;
            if (group == "Students")
            {
                if (day == "Friday")
                {
                    sum = people * 8.45;
                }
                else if (day == "Saturday")
                {
                    sum = people * 9.80;
                }
                else if (day == "Sunday")
                {
                    sum = people * 10.46;
                }

                if (people >= 30)
                {
                    sum -= sum * 0.15;
                }
            }

            else if (group == "Business")
            {
                if (day == "Friday")
                {
                    sum = people * 10.90;
                }
                else if (day == "Saturday")
                {
                    sum = people * 15.60;
                }
                else if (day == "Sunday")
                {
                    sum = people * 16;
                }

                if (people >= 100)
                {
                    sum -= sum / people * 10;
                }
            }

            else if (group == "Regular")
            {
                if (day == "Friday")
                {
                    sum = people * 15;
                }
                else if (day == "Saturday")
                {
                    sum = people * 20;
                }
                else if (day == "Sunday")
                {
                    sum = people * 22.50;
                }

                if (people >= 10 && people <= 20)
                {
                    sum -= sum * 0.05;
                }
            }


            Console.WriteLine($"Total price: {sum:f2}");

        }
    }
}
