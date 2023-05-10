using System;

public class Program
{
    public static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        string grade = Console.ReadLine();
        double total = 0;
        days--;
        switch (type)
        {
            case "room for one person": total = days * 18.00; break;
            case "apartment":
                total = days * 25.00;
                if (days > 15)
                    total -= 0.5 * total;
                else if (days >= 10)
                    total -= 0.35 * total;
                else
                    total -= 0.3 * total;
                break;
            case "president apartment":
                total = days * 35.00;
                if (days > 15)
                    total -= 0.2 * total;
                else if (days >= 10)
                    total -= 0.15 * total;
                else
                    total -= 0.1 * total;
                break;
        }
        if (grade == "positive")
            total += 0.25 * total;
        else
            total -= 0.1 * total;
        Console.WriteLine("{0:f2}", total);
    }
}