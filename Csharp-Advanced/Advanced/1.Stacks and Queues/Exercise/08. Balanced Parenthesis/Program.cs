using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parentheses = new Stack<char>();

            string input = Console.ReadLine();

            bool isBalanced = true;
            Dictionary<char, char> parDefinitions = new Dictionary<char, char>() {
            { '}', '{'}, 
            {')', '('},
            {']', '['}
            };


            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (parDefinitions.Any(x => x.Value == symbol)) //if it's an opening bracket
                {
                    parentheses.Push(symbol);
                }
                else if (parDefinitions.Any(x => x.Key == symbol)) // if it's a closing bracket
                {
                    if (parentheses.Count > 0 && parDefinitions[symbol] == parentheses.Peek())
                    { // if the closing bracket matches the last opened one
                        parentheses.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (parentheses.Count > 0)
            { 
                isBalanced = false;
            }

            Console.WriteLine(isBalanced ? "YES" : "NO"); 
        }
    }
}
