using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Ranking
{
    internal class Program
    {
        public class Candidate
        {
            public Candidate(string name, string contest, int points)
            {
                Name = name;
                ContestPoints = new Dictionary<string, int>();
                ContestPoints.Add(contest, points);
            }

            public string Name { get; set; }
            public Dictionary<string, int> ContestPoints { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string info = Console.ReadLine();
            while (info != "end of contests")
            {
                string contest = info.Split(":").First();
                string pass = info.Split(":").Last();

                contests.Add(contest, pass);

                info = Console.ReadLine();
            }

            List<Candidate> candidates = new List<Candidate>();
            var input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] splitted = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = splitted[0];
                string pass = splitted[1];
                string name = splitted[2];
                int points = int.Parse(splitted[3]);

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    if (candidates.Any(x => x.Name == name))
                    {
                        Candidate candidate = candidates.FirstOrDefault(x => x.Name == name);
                        if (candidate.ContestPoints.ContainsKey(contest) && candidate.ContestPoints[contest] < points)
                        {
                            candidate.ContestPoints[contest] = points;
                        }
                        else if (!candidate.ContestPoints.ContainsKey(contest))
                        {
                            candidate.ContestPoints.Add(contest, points);
                        }
                    }
                    else
                    {
                        candidates.Add(new Candidate(name, contest, points));
                    }
                }

                input = Console.ReadLine();
            }

            Candidate bestCandidate = candidates.OrderByDescending(x => x.ContestPoints.Values.Sum()).First();

            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.ContestPoints.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in candidates.OrderBy(x => x.Name))
            {
                Console.WriteLine(user.Name);
                foreach (var item in user.ContestPoints.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
