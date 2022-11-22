using PersonsInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.FirstAndReserveTeam
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name
        {
            get => name;
            private set => name = value;
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get => this.firstTeam.AsReadOnly();
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => this.reserveTeam.AsReadOnly();
        }
        public Team(string name)
        {
            this.Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
                firstTeam.Add(person);
            else
                reserveTeam.Add(person);
        }

        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players." +
                Environment.NewLine +
                $"Reserve team has {this.ReserveTeam.Count} players.";
        }

    }
}
