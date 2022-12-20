using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{   
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        private const string PLAYER_NAME = "Player name";
        private const int PLAYER_NUMBER = 1;
        private const string PLAYER_POSITION = "Goalkeeper";

        private const string TEAM_NAME = "Team name";
        private const int TEAM_CAPACITY = 15;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer(PLAYER_NAME, PLAYER_NUMBER, PLAYER_POSITION);
            team = new FootballTeam(TEAM_NAME, TEAM_CAPACITY);
            team.AddNewPlayer(player);
        }

        [Test]
        public void Player_Constructor()
        {
            Assert.That(PLAYER_NAME == player.Name);
            Assert.That(PLAYER_NUMBER == player.PlayerNumber);
            Assert.That(PLAYER_POSITION == player.Position);
            Assert.That(0 == player.ScoredGoals);
        }

        [Test]
        public void Constructor()
        {
            Assert.That(TEAM_NAME == team.Name);
            Assert.That(TEAM_CAPACITY == team.Capacity);
            Assert.That(team.Players != null);
        }

        [Test]
        public void Player_Exceptions()
        {
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer("", PLAYER_NUMBER, PLAYER_POSITION));
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer(PLAYER_NAME, 22, PLAYER_POSITION));
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer(PLAYER_NAME, PLAYER_NUMBER, "Error position"));
        }

        [Test]
        public void Team_Exceptions()
        {
            Assert.Throws<ArgumentException>(() => team = new FootballTeam("", TEAM_CAPACITY));
            Assert.Throws<ArgumentException>(() => team = new FootballTeam(TEAM_NAME, 1));
        }

        [Test]
        public void Team_AddNewPlayer_Capacity()
        {            
            for (int i = 1; i < 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer(i.ToString(), i, PLAYER_POSITION));
            }
            string output = team.AddNewPlayer(new FootballPlayer("name", 20, PLAYER_POSITION));
            Assert.That("No more positions available!" == output);
            Assert.That(TEAM_CAPACITY == team.Players.Count);
        }

        [Test]
        public void Team_AddNewPlayerString()
        {
            team = new FootballTeam(TEAM_NAME, TEAM_CAPACITY);
            string result = team.AddNewPlayer(player);
            Assert.That(result == $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
        }

        [Test]
        public void Team_PickPlayer()
        {
            FootballPlayer picked = team.PickPlayer(PLAYER_NAME);
            Assert.That(picked, Is.SameAs(player));
        }

        [Test]
        public void Team_PlayerScore()
        {
            string result = team.PlayerScore(PLAYER_NUMBER);
            Assert.That(result == $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
            Assert.That(1 == player.ScoredGoals);
        }
    }
}