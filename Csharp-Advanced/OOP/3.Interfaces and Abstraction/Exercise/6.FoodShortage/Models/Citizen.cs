
namespace FoodShortage.Models
{
    using Interfaces;
    public class Citizen : IBuyer
    {
        public Citizen(string id, string name, int age, string birthdate)
        {
            ID = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
            Food = 0;
        }

        public string ID { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; set; }

        public void BuyFood() => Food += 10;
    }
}
