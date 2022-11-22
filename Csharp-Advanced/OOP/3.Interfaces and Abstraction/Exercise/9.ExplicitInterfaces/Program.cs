namespace ExplicitInterfaces
{
    using System;

    using Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine(
                    (citizen as IPerson).GetName()
                    );

                Console.WriteLine(
                    (citizen as IResident).GetName()
                    );
            }
        }
    }
}
