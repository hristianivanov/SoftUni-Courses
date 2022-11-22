
namespace AnimalFarm
{
    using System;
    using _2.AnimalFarm;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            try
            {
                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(chicken);
            }
            catch (ArgumentException exception) { Console.WriteLine(exception.Message); }
        }
    }
}
