using System;

public class Program
{
    public static void Main()
    {
        string day = Console.ReadLine();

        switch (day)
        {
            case "Monday":
            case "Tuesday":
            case "Friday":
                Console.WriteLine("12"); break;
            case "Wednesday":
            case "Thursday":
                Console.WriteLine("14"); break;
            case "Saturday":
            case "Sunday":
                Console.WriteLine("16"); break;
        }
    }
}