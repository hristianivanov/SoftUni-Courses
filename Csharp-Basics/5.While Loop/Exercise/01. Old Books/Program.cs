using System;

internal class Program
{
    static void Main()
    {
        string anisBook = Console.ReadLine();
        bool isFound = false;
        int bookcount = 0;

        while (true)
        {
            string bookName = Console.ReadLine();
            if (bookName == "No More Books") break;
            if (bookName == anisBook)
            {
                isFound = true;
                break;
            }
            else bookcount++;
        }
        if (isFound) Console.WriteLine($"You checked {bookcount} books and found it.");
        else Console.WriteLine($"The book you search is not here!\nYou checked {bookcount} books.");
    }
}
