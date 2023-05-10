using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());
        for (int one = 1; one < n; one++)
            for (int two = 1; two < n; two++)
                for (char three = 'a'; three < 'a' + l; three++)
                    for (char four = 'a'; four < 'a' + l; four++)
                        for (int five = one + 1; five <= n; five++)
                            if (five > two) Console.Write("{0}{1}{2}{3}{4} ", one, two, three, four, five);
    }
}