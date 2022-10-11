using System;
using System.Collections.Generic;

namespace _8._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }
            }
            while ((input = Console.ReadLine()) != "END")
            {
                vipGuests.Remove(input);
                regularGuests.Remove(input);
            }
            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            if (vipGuests.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }

            if (regularGuests.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regularGuests));
            }
        }
    }
}
