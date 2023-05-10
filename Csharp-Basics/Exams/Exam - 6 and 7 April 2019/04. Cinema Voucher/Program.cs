using System;

public class Program
{
    static void Main()
    {
        int voucher = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int tickets = 0;
        int other = 0;

        while (input != "End")
        {
            int price = 0;
            if (input.Length > 8)
            {
                price = input[0] + input[1];
                if (price <= voucher) tickets++;
            }
            else
            {
                price = input[0];
                if (price <= voucher) other++;
            }
            if (price > voucher) break;
            voucher -= price;
            input = Console.ReadLine();
        }

        Console.WriteLine(tickets);
        Console.WriteLine(other);
    }
}