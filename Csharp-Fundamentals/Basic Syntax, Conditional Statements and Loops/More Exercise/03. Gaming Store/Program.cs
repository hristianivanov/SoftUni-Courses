using System;

namespace _03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            //OutFall 4                      $39.99
            //CS: OG                         $15.99
            //Zplinter Zell                  $19.99
            //Honored 2                      $59.99
            //RoverWatch                     $29.99
            //RoverWatch Origins Edition     $39.99


            double price = 0;
            double spent = 0;

            while (input != "Game Time" && balance!=0)
            {
                switch (input)
                {
                    case "OutFall 4":price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;

                    default:
                        price = 0;
                        Console.WriteLine("Not Found");
                        break;
                }
                if (balance>price && price != 0)
                {
                    Console.WriteLine($"Bought {input}"); balance -= price; spent += price;
                }
                else if (price>balance && price != 0)
                {
                    Console.WriteLine("Too Expensive");
                }

                input = Console.ReadLine();
            }

            if (balance==0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${spent:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
