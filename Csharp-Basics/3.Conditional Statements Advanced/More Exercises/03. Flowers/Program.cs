﻿//Магазин за цветя предлага 3 вида цветя: хризантеми, рози и лалета. Цените зависят от сезона.
//Сезон	Хризантеми	Рози	Лалета
//Пролет / Лято	2.00 лв./бр.	4.10 лв./бр.	2.50 лв./бр.
//Есен / Зима	3.75 лв./бр.	4.50 лв./бр.	4.15 лв./бр.
//В празнични дни цените на всички цветя се увеличават с 15%. Предлагат се следните отстъпки:
//•	За закупени повече от 7 лалета през пролетта – 5% от цената на целият букет.
//•	За закупени 10 или повече рози през зимата – 10% от цената на целият букет.
//•	За закупени повече от 20 цветя общо през всички сезони – 20% от цената на целият букет.
//Отстъпките се правят по така написания ред и могат да се наслагват! Всички отстъпки важат след оскъпяването за празничен ден!
//Цената за аранжиране на букета винаги е 2лв. Напишете програма, която изчислява цената за един букет.
//Вход
//Входът се чете от конзолата и съдържа точно 5 реда:
//•	На първия ред е броят на закупените хризантеми – цяло число в интервала [0 ... 200]
//•	На втория ред е броят на закупените рози – цяло число в интервала [0 ... 200]
//•	На третия ред е броят на закупените лалета – цяло число в интервала [0 ... 200]
//•	На четвъртия ред е посочен сезона – [Spring, Summer, Аutumn, Winter]
//•	На петия ред е посочено дали денят е празник – [Y – да / N - не]
//Изход
//Да се отпечата на конзолата 1 число – цената на цветята, форматирана до вторият знак след десетичната запетая.

using System;


class Program
{
    static void Main(string[] args)
    {
        int chryzz = int.Parse(Console.ReadLine());
        int roses = int.Parse(Console.ReadLine());
        int tulips = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        bool isHoliday = Console.ReadLine() == "Y";

        double total;
        if (season == "Spring" || season == "Summer") total = chryzz * 2.00 + roses * 4.10 + tulips * 2.50;
        else total = chryzz * 3.75 + roses * 4.50 + tulips * 4.15;
        if (isHoliday) total *= 1.15;

        if (tulips > 7 && season == "Spring") total *= 0.95;
        if (roses >= 10 && season == "Winter") total *= 0.90;
        if (chryzz + roses + tulips > 20) total *= 0.80;
        total += 2;

        Console.WriteLine($"{total:f2}");
    }
}