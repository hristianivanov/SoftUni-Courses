using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.FoodFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>
            {
                {
                    "pear", new HashSet<char>()
                },
                {
                    "flour", new HashSet<char>()
                },
                {
                    "pork", new HashSet<char>()
                },
                {
                    "olive", new HashSet<char>()
                }
            };

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            while (consonants.Any())
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        word.Value.Add(vowel);
                    }

                    if (word.Key.Contains(consonant))
                    {
                        word.Value.Add(consonant);
                    }
                }

                vowels.Enqueue(vowel);
            }

            var foundWords = words.Where(word=>word.Key.Count()==word.Value.Count).ToDictionary(word=>word.Key, word=>word.Value);
            Console.WriteLine($"Words found: {foundWords.Count()}");
            foreach (var item in foundWords)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
