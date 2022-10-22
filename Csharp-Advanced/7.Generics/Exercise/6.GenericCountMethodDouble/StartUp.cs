using System;

namespace _6.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            for (int i = 0; i < count; i++)
            {
                double item = double.Parse(Console.ReadLine());

                box.Items.Add(item);
            }
            Console.WriteLine(box.Count(double.Parse(Console.ReadLine())));
        }
    }
}
