using System;

namespace Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftBracket = 0;
            int rightBracket = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input[0]=='(')
                {
                    leftBracket++;
                }
                else if (input[0] == ')')
                {
                    rightBracket++;
                }
                if (rightBracket  > leftBracket)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }

            if (rightBracket==leftBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }

              
    }
}
