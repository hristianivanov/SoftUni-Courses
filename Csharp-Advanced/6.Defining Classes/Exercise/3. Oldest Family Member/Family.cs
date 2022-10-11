using System.Collections.Generic;
using System.Linq;

namespace _3._Oldest_Family_Member
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }
        public void AddMember(Person person)=> this.people.Add(person);

        public Person GetOldestMember()=> this.people.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}