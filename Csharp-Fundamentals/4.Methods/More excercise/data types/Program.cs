using System;

namespace data_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var data = Console.ReadLine();
            switch (input)
            {
                case "int":
                    Console.WriteLine(int.Parse(data)*2); break;
                case "real":
                    Console.WriteLine(double.Parse(data) * 1.5); break;
                case "string":
                    Console.WriteLine($"${data}$"); break;
                default:
                    break;
            }
        }
    }
}
