using System;

public class Program
{
    public static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        string symbol = Console.ReadLine();

        switch (symbol)
        {
            case "+":
                {
                    int result = n1 + n2;
                    if (result % 2 == 1)
                        Console.WriteLine("{0} + {1} = {2} - odd", n1, n2, result);
                    else
                        Console.WriteLine("{0} + {1} = {2} - even", n1, n2, result);
                    break;
                }
            case "-":
                {
                    int result = n1 - n2;
                    if (Math.Abs(result % 2) == 1) 
                        Console.WriteLine("{0} - {1} = {2} - odd", n1, n2, result);
                    else
                        Console.WriteLine("{0} - {1} = {2} - even", n1, n2, result);
                    break;
                }
            case "*":
                {
                    int result = n1 * n2;
                    if (result % 2 == 1)
                        Console.WriteLine("{0} * {1} = {2} - odd", n1, n2, result);
                    else
                        Console.WriteLine("{0} * {1} = {2} - even", n1, n2, result);
                    break;
                }
            case "/":
                {
                    if (n2 == 0) 
                        Console.WriteLine("Cannot divide {0} by zero", n1);
                    else
                    {
                        double result = n1 * 1.0 / n2 * 1.0;
                        Console.WriteLine("{0} / {1} = {2:f2}", n1, n2, result);
                    }
                    break;
                }
            case "%":
                {
                    if (n2 == 0) 
                        Console.WriteLine("Cannot divide {0} by zero", n1);
                    else
                    {
                        int result = n1 % n2;
                        Console.WriteLine("{0} % {1} = {2}", n1, n2, result);
                    }
                    break;
                }
        }
    }
}