using System;

namespace Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();
            SearchForVoweles(inputText);
        }

        private static void SearchForVoweles(string text)
        {
            int count = 0;
            // Console.WriteLine(text.Count(vowles => "aouei".Contains(vowles)));
            foreach (char vowel in text)
            {
                if ("aouei".Contains(vowel))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
