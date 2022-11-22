using _1.ClassBoxData;
using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {

                Box box = new Box(double.Parse(Console.ReadLine()),
                                                 double.Parse(Console.ReadLine()),
                                                 double.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
            catch (ArgumentException exception) { Console.WriteLine(exception.Message); }
        }
    }
}
