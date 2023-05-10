using System;

internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int salary = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n && salary > 0; i++)
        {
            string str = Console.ReadLine();
            switch (str)
            {
                case "Facebook": salary -= 150; break;
                case "Instagram": salary -= 100; break;
                case "Reddit": salary -= 50; break;
            }
        }
        if (salary <= 0)
            Console.WriteLine("You have lost your salary.");
        else
            Console.WriteLine(salary);
    }
}
