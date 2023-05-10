using System;

internal class Program
{
    static void Main(string[] args)
    {
        int students = int.Parse(Console.ReadLine());
        int two = 0, three = 0, four = 0, five = 0;
        double allGrades = 0;

        for (int i = 0; i < students; i++)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade < 3) 
                two++;
            else if (grade < 4) 
                three++;
            else if (grade < 5) 
                four++;
            else
                five++;
            allGrades += grade;
        }

        Console.WriteLine($"Top students: {five * 100.0 / students:f2}%");
        Console.WriteLine($"Between 4.00 and 4.99: {four * 100.0 / students:f2}%");
        Console.WriteLine($"Between 3.00 and 3.99: {three * 100.0 / students:f2}%");
        Console.WriteLine($"Fail: {two * 100.0 / students:f2}%");
        Console.WriteLine($"Average: {allGrades / students:f2}");
    }
}