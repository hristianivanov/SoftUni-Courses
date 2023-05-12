using System;
using System.Collections.Generic;

namespace Judge
{
    internal class Program
    {
        public class UserAndPoints
        {
            public UserAndPoints(string username, int points)
            {
                Username = username;
                Points = points;
            }
            public string Username { get; set; }
            public int Points { get; set; }
        }
        static void Main(string[] args)
        {
            var input = string.Empty;

            Dictionary < string,UserAndPoints> keyValuePairs = new Dictionary<string,UserAndPoints> ();


            while ((input = Console.ReadLine()) != "no more time")
            {
                var info = input.Split(" -> ");
                var username = info[0];
                var contest = info[1];
                var points = int.Parse(info[2]);

                //thinks about whether can add same key with different values
                if (keyValuePairs.ContainsKey(contest))
                {
                    if ()
                    {

                    }
                }
                else
                {
                    keyValuePairs.Add(contest, new UserAndPoints(username, points));
                }
            }
        }
    }
}
