using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Until you receive "exam finished" you will be receiving participant submissions in the following format: "{username}-{language}-{points}".
            //You can receive a ban command -> "{username}-banned"
            //The points of the participant will always be a valid integer in the range[0 - 100];

            Dictionary<string, int> usernamePoints = new Dictionary<string, int>();
            Dictionary<string,int> languageCnt = new Dictionary<string, int>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "exam finished")
                {
                    break;
                }
                var splitted = command.Split('-');

                var username = splitted[0];

                if (splitted.Length==3)
                {
                    var language = splitted[1];
                    var points = int.Parse(splitted[2]);

                    if (!usernamePoints.ContainsKey(username))
                    {
                        usernamePoints.Add(username, points);
                    }
                    if (points > usernamePoints[username])
                    {
                        usernamePoints[username] = points;
                    }


                    if (!languageCnt.ContainsKey(language))
                    {
                        languageCnt.Add(language, 0);
                    }
                    languageCnt[language]++;
                }
                else if(splitted.Length==2 && splitted[1]=="banned")
                {
                    usernamePoints.Remove(username);
                }
            }

            Console.WriteLine("Results:");
            usernamePoints = usernamePoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x=>x.Key,y=>y.Value);
            foreach (var item in usernamePoints)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            languageCnt = languageCnt.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in languageCnt)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
