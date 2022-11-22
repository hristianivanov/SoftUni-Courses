using System;
using System.Collections.Generic;
using System.Text;

namespace _3.PlayersMonsters
{
    public class Hero
    {
        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username { get => username; set => username = value; }
        public int Level { get => level; set => level = value; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
