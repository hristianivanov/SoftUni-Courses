using System;

namespace Decrypting_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int newLetter = key;
            char[] output = new char[n];
            for (int i = 0; i < n; i++)
            {
               char letter = char.Parse(Console.ReadLine());
                newLetter += letter;
                output[i] = (char)newLetter;
                newLetter = key;
            }
            Console.WriteLine(String.Join("",output));
        }
    }
}
