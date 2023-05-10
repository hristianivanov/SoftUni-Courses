using System;

public class Program
{
    static void Main()
    {
        int amount = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        bool delivery = Console.ReadLine() == "With delivery";
        double price = 0;

        switch (type)
        {
            case "90X130":
                price = 110.00;
                if (amount > 60) price -= price * 0.08;
                else if (amount > 30) price -= price * 0.05;
                break;
            case "100X150":
                price = 140.00;
                if (amount > 80) price -= price * 0.10;
                else if (amount > 40) price -= price * 0.06;
                break;
            case "130X180":
                price = 190.00;
                if (amount > 50) price -= price * 0.12;
                else if (amount > 20) price -= price * 0.07;
                break;
            case "200X300":
                price = 250.00;
                if (amount > 50) price -= price * 0.14;
                else if (amount > 25) price -= price * 0.09;
                break;
        }
        double total = price * amount;
        if (delivery) total += 60.00;
        if (amount > 99) total -= total * 0.04;

        if (amount < 10) Console.WriteLine("Invalid order");
        else Console.WriteLine($"{total:f2} BGN");
    }
}