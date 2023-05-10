using System;

public class Program
{
    static void Main()
    {
        string bestWord = string.Empty;
        int bestValue = int.MinValue;
        string input = Console.ReadLine();

        while (input != "End of words")
        {
            int value = 0;
            for (int i = 0; i < input.Length; i++)
            {
                value += input[i];
            }
            if (input[0] == 'a' || input[0] == 'e' || input[0] == 'i' || input[0] == 'o' || input[0] == 'u' || input[0] == 'y' ||
                input[0] == 'A' || input[0] == 'E' || input[0] == 'I' || input[0] == 'O' || input[0] == 'U' || input[0] == 'Y')
                value *= input.Length;
            else value /= input.Length;

            if (value > bestValue)
            {
                bestValue = value;
                bestWord = input;
            }
            input = Console.ReadLine();
        }

        Console.WriteLine($"The most powerful word is {bestWord} - {bestValue}");
    }
}