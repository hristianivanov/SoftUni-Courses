namespace BorderControl.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> entities = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];
                if (cmdArgs.Length == 2)
                {
                    string id = cmdArgs[1];
                    entities.Add(new Robot(id,name));
                }
                else if (cmdArgs.Length == 3)
                {
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    entities.Add(new Citizen(id, name, age));
                }
            }

            string fakeID = Console.ReadLine();

            entities.ForEach(entity => entity.CheckId(fakeID));
        }
    }
}
