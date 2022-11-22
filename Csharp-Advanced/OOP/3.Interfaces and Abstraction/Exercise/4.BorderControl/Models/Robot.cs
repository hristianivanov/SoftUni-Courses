
namespace BorderControl.Models
{
    using System;

    using Interfaces;

    public class Robot : IIdentifiable
    {
        public Robot(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public void CheckId(string id)
        {
            if (Id.EndsWith(id))
                Console.WriteLine(Id);
        }
    }
}
