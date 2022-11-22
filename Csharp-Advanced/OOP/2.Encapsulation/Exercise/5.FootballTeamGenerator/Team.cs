using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> playerList;

        private Team()
        {
            this.playerList = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameCannotBeNullOrWhiteSpace);
                }
                this.name = value;
            }
        }
        private int Rating
            => this.playerList.Count > 0 ?
            (int)Math.Round(this.playerList.Average(p => p.OverallRating), 0) : 0;

        public void AddPlayer(Player player) => this.playerList.Add(player);
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.playerList.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.MissingPlayerMessage, playerName, this.Name));
            }

            this.playerList.Remove(playerToRemove);
        }
        public override string ToString()=>$"{this.Name} - {this.Rating}";
    }
}
