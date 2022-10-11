using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var info = input.Split("|").Select(p => p.Trim()).ToList();

            Dictionary<string, List<string>> notebook = new Dictionary<string, List<string>>();

            for (int i = 0; i < info.Count; i++)
            {
                var text = info[i].Split(":");
                var word = text[0];
                var definition = text[1].Trim();


                if (notebook.ContainsKey(word))
                {
                    notebook[word].Add(definition);
                }
                else
                {
                    notebook.Add(word, new List<string>() { definition });
                }
            }

            var testWords = Console.ReadLine().Split("|").Select(p => p.Trim()).ToList();

            var command = Console.ReadLine();

            if (command == "Test")
            {
                for (int i = 0; i < testWords.Count; i++)
                {
                    if (notebook.ContainsKey(testWords[i]))
                    {

                        Console.WriteLine($"{testWords[i]}:");
                        foreach (var item in notebook[testWords[i]])
                        {
                            Console.WriteLine($" -{item}");
                        }

                    }
                }

            }
            else if (command == "Hand Over")
            {
                foreach (var item in notebook)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
