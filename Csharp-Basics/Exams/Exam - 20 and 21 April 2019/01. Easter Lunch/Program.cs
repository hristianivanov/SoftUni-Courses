using System;

public class Program
{
    public static void Main()
    {
        int yeastAmount = int.Parse(Console.ReadLine());
        int eggPacks = int.Parse(Console.ReadLine());
        int cookiesKg = int.Parse(Console.ReadLine());
        int eggs = eggPacks * 12;
        double totalPrice = yeastAmount * 3.20 + eggPacks * 4.35 + cookiesKg * 5.40 + eggs * 0.15;

        Console.WriteLine("{0:f2}", totalPrice);
    }
}