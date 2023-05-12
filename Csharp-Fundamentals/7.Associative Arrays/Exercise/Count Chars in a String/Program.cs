using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            Dictionary<char,int> pair = new Dictionary<char,int>();

            foreach (var word in input)
            {

                for (int i = 0; i < word.Length; i++)
                {
                    if (pair.ContainsKey(word[i]))
                    {
                        pair[word[i]]++;
                    }
                    else
                    {
                        pair.Add(word[i], 1);
                    }
                }
                
            }
            foreach (var item in pair)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
