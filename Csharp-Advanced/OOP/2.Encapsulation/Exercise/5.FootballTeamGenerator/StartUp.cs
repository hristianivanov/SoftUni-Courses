﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FootballTeamGenerator
{
    public class StartUp
    {
        private static List<Team> teamList;
        static void Main(string[] args)
        {
            teamList = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(';');
                string cmdType = cmdArgs[0];
                string teamName = cmdArgs[1];

                try
                {
                    switch (cmdType)
                    {
                        case "Team": AddNewTeam(teamName); break;
                        case "Add": AddPlayerToTeam(teamName, cmdArgs); break;
                        case "Remove": RemovePlayerFromTeam(teamName, cmdArgs[2]); break;
                        case "Rating": RateTeam(teamName); break;

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
        static void AddNewTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teamList.Add(newTeam);
        }
        static void AddPlayerToTeam(string teamName, string[] cmdArgs)
        {
            Team joiningTeam = teamList
                        .FirstOrDefault(t => t.Name == teamName);
            if (joiningTeam == null)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.InexistingTeamMessage, teamName));
            }

            Player joiningPlayer = CreateNewPlayer(cmdArgs);
            joiningTeam.AddPlayer(joiningPlayer);
        }
        static Player CreateNewPlayer(string[] cmdArgs)
        {
            string playerName = cmdArgs[2];
            int endurance = int.Parse(cmdArgs[3]);
            int sprint = int.Parse(cmdArgs[4]);
            int dribble = int.Parse(cmdArgs[5]);
            int passing = int.Parse(cmdArgs[6]);
            int shooting = int.Parse(cmdArgs[7]);

            Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            return newPlayer;
        }
        static void RemovePlayerFromTeam(string teamName, string playerName)
        {
            Team removingTeam = teamList
                        .FirstOrDefault(t => t.Name == teamName);
            if (removingTeam == null)
            {
                throw new InvalidOperationException(string.Format(
            ExceptionMessages.InexistingTeamMessage, teamName));
            }

            removingTeam.RemovePlayer(playerName);
        }
        static void RateTeam(string teamName)
        {
            Team teamToRate = teamList
                        .FirstOrDefault(t => t.Name == teamName);
            if (teamToRate == null)
            {
                throw new InvalidOperationException(string.Format(
            ExceptionMessages.InexistingTeamMessage, teamName));
            }

            Console.WriteLine(teamToRate);
        }
    }
}
