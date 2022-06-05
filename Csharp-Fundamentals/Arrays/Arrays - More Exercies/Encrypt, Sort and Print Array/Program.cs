using System;
using System.Linq;

namespace Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        public static bool IsVowel(char letter)
        {
            string vowels = "aeiouAEIOU";
            return vowels.Contains(letter);
        }
        public static bool IsConsonant(char letter)
        {
            string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
            return consonants.Contains(letter);
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());         

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                int sum = 0;

                for (int j = 0; j < name.Length; j++)
                {
                    char curChar = name[j];

                    if (IsVowel(curChar)) 
                    {
                        sum += curChar * name.Length;
                    }
                    else
                    {
                        sum += curChar / name.Length;
                    }
                }

                arr[i] = sum;
            }

            Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }



        }
    }
}
