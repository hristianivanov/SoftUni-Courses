using System;

public class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int student = 0;
        int standard = 0;
        int kid = 0;

        while (input != "Finish")
        {
            int seats = int.Parse(Console.ReadLine());
            int seatstaken = 0;
            for (int i = 0; i < seats; i++)
            {
                bool isEnd = false;
                string type = Console.ReadLine();
                switch (type)
                {
                    case "student":
                        student++; seatstaken++;
                        break;
                    case "standard":
                        standard++; seatstaken++;
                        break;
                    case "kid":
                        kid++; seatstaken++;
                        break;
                    case "End": isEnd = true; break;
                }
                if (isEnd) break;
            }
            Console.WriteLine($"{input} - {seatstaken * 100.0 / seats:f2}% full.");
            input = Console.ReadLine();
        }

        int allTickets = student + standard + kid;
        Console.WriteLine($"Total tickets: {allTickets}");
        Console.WriteLine($"{student * 100.0 / allTickets:f2}% student tickets.");
        Console.WriteLine($"{standard * 100.0 / allTickets:f2}% standard tickets.");
        Console.WriteLine($"{kid * 100.0 / allTickets:f2}% kids tickets.");
    }
}