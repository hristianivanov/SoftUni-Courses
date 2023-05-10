using System;

public class Program
{
    public static void Main()
    {
        string town = Console.ReadLine();
        double sales = double.Parse(Console.ReadLine());
        double rate = 0;
        double comission = 0;
        bool isValid = true;

        if (sales < 0)
            isValid = false;

        switch (town)
        {
            case "Sofia":
                if (sales <= 500) rate = 0.05;
                else if (sales <= 1000) rate = 0.07;
                else if (sales <= 10000) rate = 0.08;
                else rate = 0.12;
                break;
            case "Varna":
                if (sales <= 500) rate = 0.045;
                else if (sales <= 1000) rate = 0.075;
                else if (sales <= 10000) rate = 0.10;
                else rate = 0.13;
                break;
            case "Plovdiv":
                if (sales <= 500) rate = 0.055;
                else if (sales <= 1000) rate = 0.08;
                else if (sales <= 10000) rate = 0.12;
                else rate = 0.145;
                break;
            default: isValid = false; break;
        }

        comission = sales * rate;

        if (isValid)
            Console.WriteLine("{0:f2}", comission);
        else
            Console.WriteLine("error");
    }
}