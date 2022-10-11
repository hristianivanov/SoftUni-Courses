using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var password = Console.ReadLine();

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Complete")
            {
                var action = input[0];

                if (action == "Make")
                {
                    password = UppperOrLower(password, input);
                }

                else if (action == "Insert")
                {
                    password = Insert(password, input);

                }
                else if (action == "Replace")
                {
                    password = Replace(password, input);
                }
                else if (action == "Validation")
                {
                    Validation(password);
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

        }

        private static void Validation(string password)
        {
            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long!");
            }
            else if (!Regex.IsMatch(password, @"^[A-Za-z0-9_]+$"))
            {
                Console.WriteLine("Password must consist only of letters, digits and _!");
            }
            else if (password.Count(x => char.IsLetter(x) && char.IsUpper(x)) == 0)
            {
                Console.WriteLine("Password must consist at least one uppercase letter!");
            }
            else if (password.Count(x => char.IsLetter(x) && char.IsLower(x)) == 0)
            {
                Console.WriteLine("Password must consist at least one lowercase letter!");
            }
            else if (password.Count(x => char.IsDigit(x)) == 0)
            {
                Console.WriteLine("Password must consist at least one digit!");
            }
        }

        private static string Replace(string password, string[] input)
        {
            var oldChar = char.Parse(input[1]);
            var value = int.Parse(input[2]);

            var newChar = Convert.ToChar((int)oldChar + value);

            password = password.Replace(oldChar, newChar);

            Console.WriteLine(password);
            return password;
        }

        private static string Insert(string password, string[] input)
        {
            var index = int.Parse(input[1]);
            var value = input[2];

            if (index >= 0 && index < password.Length)
            {
                password = password.Insert(index, value);
                Console.WriteLine(password);
            }

            return password;
        }

        private static string UppperOrLower(string password, string[] input)
        {
            var index = int.Parse(input[2]);
            var value = password[index];
            if (input[1] == "Upper")
            {
                password = Upper(password, index, value);
            }
            else if (input[1] == "Lower")
            {
                password = Lower(password, index, value);
            }
            Console.WriteLine(password);
            return password;
        }

        private static string Lower(string password, int index, char value)
        {
            password = password.Remove(index, 1);
            password = password.Insert(index, value.ToString().ToLower());
            return password;
        }

        private static string Upper(string password, int index, char value)
        {
            password = password.Remove(index, 1);
            password = password.Insert(index, value.ToString().ToUpper());
            return password;
        }
    }
}
