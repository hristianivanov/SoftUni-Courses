using System;


internal class Program
{
    static void Main(string[] args)
    {
        string word = string.Empty;
        string input = Console.ReadLine();
        bool gotC = false;
        bool gotO = false;
        bool gotN = false;

        while (input != "End")
        {
            char symbol = input[0];
            bool isValid = (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z');
            if (!isValid) { input = Console.ReadLine(); continue; }
            else if (symbol == 'c' && !gotC) gotC = true;
            else if (symbol == 'o' && !gotO) gotO = true;
            else if (symbol == 'n' && !gotN) gotN = true;
            else word += symbol;

            if (gotC && gotO && gotN)
            {
                gotO = false; gotN = false; gotC = false;
                Console.Write(word + " ");
                word = String.Empty;
            }
            input = Console.ReadLine();
        }
    }
}