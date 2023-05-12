using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> output = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                int number = input % 10;
                var numberOfDigits = input.ToString().Length;
                var letter = "";

                switch (number)
                {
                    case 1: letter = ""; break;

                    case 2:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "a"; break;
                            case 2: letter = "b"; break;
                            case 3: letter = "c"; break;
                        }
                        break;
                    case 3:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "d"; break;
                            case 2: letter = "e"; break;
                            case 3: letter = "f"; break;
                        }
                        break;
                    case 4:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "g"; break;
                            case 2: letter = "h"; break;
                            case 3: letter = "i"; break;
                        }
                        break;
                    case 5:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "j"; break;
                            case 2: letter = "k"; break;
                            case 3: letter = "l"; break;
                        }
                        break;
                    case 6:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "m"; break;
                            case 2: letter = "n"; break;
                            case 3: letter = "o"; break;
                        }
                        break;
                    case 7:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "p"; break;
                            case 2: letter = "q"; break;
                            case 3: letter = "r"; break;
                            case 4: letter = "s"; break;
                        }
                        break;
                    case 8:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "t"; break;
                            case 2: letter = "u"; break;
                            case 3: letter = "v"; break;
                        }
                        break;
                    case 9:
                        switch (numberOfDigits)
                        {
                            case 1: letter = "w"; break;
                            case 2: letter = "x"; break;
                            case 3: letter = "y"; break;
                            case 4: letter = "z"; break;
                        }
                        break;

                    case 0: letter = " "; break;
                }
                output.Add(letter);
            }
            Console.WriteLine(String.Join("",output));
        }
    }
}
