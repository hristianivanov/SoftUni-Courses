using System;
using System.Linq;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var message = Console.ReadLine();

            var command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Reveal")
            {
                if (command[0] == "InsertSpace")
                {
                    message = InsertSpace(message, command);
                    Console.WriteLine(message);
                }
                else if (command[0] == "Reverse")
                {
                    if (message.Contains(command[1]))
                    {
                        message = Reverse(message, command);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "ChangeAll")
                {
                    message = ChangeAll(message, command);
                    Console.WriteLine(message);
                }

                command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {message}");

        }

        private static string ChangeAll(string message, string[] command)
        {
            var substring = command[1];
            var replacement = command[2];
            message = message.Replace(substring, replacement);
            return message;
        }

        private static string Reverse(string message, string[] command)
        {
            var substring = command[1];

            var replace = new string(substring.ToCharArray().Reverse().ToArray());
            message = message.Remove(message.IndexOf(substring), substring.Length) + replace;
            return message;
        }

        private static string InsertSpace(string message, string[] command)
        {
            message = message.Insert(int.Parse(command[1]), " ");
            return message;
        }
    }
}
