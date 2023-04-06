﻿//Напишете програма, която да принтира на конзолата всички комбинации от 3 букви в зададен интервал,
//като се пропускат комбинациите съдържащи зададена от конзолата буква. Накрая трябва да се изпринтира броят на отпечатаните комбинации.
//Вход
//Входът се чете от конзолата и съдържа точно 3 реда:
//Ред 1.Малка буква от английската азбука за начало на интервала – от ‘a’ до ‚z’.
//Ред 2.	Малка буква от английската азбука за край на интервала  – от първата буква до ‚z’.
//Ред 3.	Малка буква от английската азбука – от ‘a’ до ‚z’ – като комбинациите съдържащи тази буквата се пропускат.
//Изход
//Да се отпечатат на един ред всички комбинации отговарящи на условието плюс броят им разделени с интервал.

using System;


class Program
{
    static void Main(string[] args)
    {
        char lower = char.Parse(Console.ReadLine());
        char higher = char.Parse(Console.ReadLine());
        char exception = char.Parse(Console.ReadLine());
        int count = 0;

        for (char c1 = lower; c1 <= higher; c1++)
        {
            for (char c2 = lower; c2 <= higher; c2++)
            {
                for (char c3 = lower; c3 <= higher; c3++)
                {
                    if (c1 != exception && c2 != exception && c3 != exception)
                    {
                        Console.Write($"{c1}{c2}{c3} ");
                        count++;
                    }

                }
            }
        }
        Console.WriteLine(count);
    }
}