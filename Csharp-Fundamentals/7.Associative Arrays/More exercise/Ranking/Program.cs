using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    //40/100
    internal class Program
    {
        public class Contest
        {
            public Contest(string name, string password)
            {
                Name = name;
                Password = password;
            }

            public string Name { get; set; }
            public string Password { get; set; }

        }
        public class Info
        {
            public Info(string contest, int points, int sum)
            {
                ContestAndPoints = new Dictionary<string, int>();
                ContestAndPoints.Add(contest, points);
                Sum = sum;
            }

            public Dictionary<string, int> ContestAndPoints { get; set; }

            public int Sum { get; set; }
        }
        static void Main(string[] args)
        {
            //•	Strings in format "{contest}:{password for contest}" until the "end of contests" command.There will be no case with two equal contests
            //•	Strings in format "{contest}=>{password}=>{username}=>{points}" until the "end of submissions" command.
            //•	There will be no case with 2 or more users with the same total points!

            var info = Console.ReadLine().Split(":").ToList();

            var contests = new List<Contest>();

            while (info[0] != "end of contests")
            {
                Contest contest = new Contest(info[0], info[1]);

                contests.Add(contest);

                info = Console.ReadLine().Split(":").ToList();
            }

            var submissions = Console.ReadLine().Split("=>").ToList();

            Dictionary<string, Info> users = new Dictionary<string, Info>();


            while (submissions[0] != "end of submissions")
            {
                var contest = submissions[0];
                var password = submissions[1];
                var user = submissions[2];
                var points = int.Parse(submissions[3]);


                if (contests.Any(x => x.Name == contest && x.Password == password))
                {
                    if (users.ContainsKey(user)) // same user
                    {
                        // same contest
                        if (users[user].ContestAndPoints.ContainsKey(contest))
                        {

                            if (points > users[user].ContestAndPoints.GetValueOrDefault(contest))
                            {
                                users[user].ContestAndPoints[contest] = points;
                                users[user].Sum += points - users[user].ContestAndPoints[contest];
                            }


                        }
                        // new contest
                        else
                        {
                            users[user].ContestAndPoints.Add(contest, points);
                            users[user].Sum += points;
                        }
                    }
                    // new user new contest
                    else
                    {
                        users.Add(user, new Info(contest, points, points));

                    }
                }


                submissions = Console.ReadLine().Split("=>").ToList();
            }

            Console.WriteLine($"Best candidate is {users.Max(x => x.Key)} with total {users.Max(x => x.Value.Sum)} points.");
            Console.WriteLine("Ranking: ");

            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                //"#  {contest1} -> {points}"
                foreach (var item in user.Value.ContestAndPoints.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
