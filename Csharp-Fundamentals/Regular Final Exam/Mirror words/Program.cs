using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Mirror_words
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string patern = @"([@#])(?<word>[a-zA-Z]{3,})\1\1(?<reversedWord>[a-zA-Z]{3,})\1";

            Regex regex = new Regex(patern);

            MatchCollection matchCollection = regex.Matches(input);

            if (matchCollection.Count >= 1)
            {
                Console.WriteLine($"{matchCollection.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!"); return;
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Match item in matchCollection)
            {
                string word = item.Groups["word"].Value;
                string reversedWord = item.Groups["reversedWord"].Value;

                if (IsValid(word,reversedWord))
                {
                    stringBuilder.Append($"{word} <=> {reversedWord}, ");
                }

            }

            var output = stringBuilder.ToString().TrimEnd(',',' ');

            if (stringBuilder.Length == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(output);
            }



        }

        private static bool IsValid(string word,string reversedWord)
        {
            string check = new string(word.ToCharArray().Reverse().ToArray());
            if (check==reversedWord)
            {
                return true;
            }
            return false;
        }
    }
}
