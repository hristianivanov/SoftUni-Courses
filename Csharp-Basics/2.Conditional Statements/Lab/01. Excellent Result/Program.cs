﻿using System;

internal class Program
{
    static void Main()
    {
        double grade = double.Parse(Console.ReadLine());

        if (grade >= 5.50)
        {
            Console.WriteLine("Excellent!");
        }
    }
}
