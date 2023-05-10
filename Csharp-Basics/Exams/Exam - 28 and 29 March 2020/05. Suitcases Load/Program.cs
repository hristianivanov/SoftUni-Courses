using System;

internal class Program
{
    static void Main(string[] args)
    {
        double limit = double.Parse(Console.ReadLine());
        string suitcase = Console.ReadLine();
        double filling = 0;
        int counter = 0;

        while (suitcase != "End")
        {
            double suitcase2 = double.Parse(suitcase);
            counter++;
            if (counter % 3 == 0)
            {
                filling += suitcase2 * 1.1;
            }
            else filling += suitcase2;

            if (filling > limit)
            {
                Console.WriteLine("No more space!");
                counter--;
                break;
            }


            suitcase = Console.ReadLine();

        }
        if (limit >= filling)
        {
            Console.WriteLine("Congratulations! All suitcases are loaded!");
        }
        Console.WriteLine($"Statistic: {counter} suitcases loaded.");
    }
}
