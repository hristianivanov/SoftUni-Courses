using System;

internal class Program
{
    static void Main()
    {
        char lastSector = char.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        int seatsOdd = int.Parse(Console.ReadLine());
        int totalSeats = 0;

        for (char currSector = 'A'; currSector <= lastSector; currSector++)
        {
            for (int currRow = 1; currRow <= rows; currRow++)
            {
                int seats = seatsOdd;
                if (currRow % 2 == 0) seats += 2;
                for (char currSeat = 'a'; currSeat < 'a' + seats; currSeat++)
                {
                    Console.WriteLine($"{currSector}{currRow}{currSeat}");
                    totalSeats++;
                }
            }
            rows++;
        }
        Console.WriteLine(totalSeats);
    }
}