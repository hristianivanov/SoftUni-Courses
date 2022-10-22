using System;

namespace _5.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();

                box.Items.Add(item);
            }
            Console.WriteLine(box.Count(Console.ReadLine()));
        }
    }
}
