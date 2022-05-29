using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = new string(value: username.ToCharArray().Reverse().ToArray());


            string input = Console.ReadLine();

            int count = 0;

            while (input != password.ToString() && count != 3)
            {
                count++;
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }
            if (input == password.ToString())
            {
                Console.WriteLine($"User {username} logged in.");
            }
            else
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
