﻿//Бабата на Деси всяка година приготвя обяд за семейството си за Великден.
//Напишете програма, която изчислява какви разходи ще има по приготвянето на обяда,
//като знаете колко броя козунаци, кори с яйца и килограма курабии е купила.
//Цените на продуктите са следните:
//•	Козунак  – 3.20 лв.
//•	Яйца –  4.35 лв.за кора с 12 яйца
//•	Курабии – 5.40 лв. за килограм
//•	Боя за яйца - 0.15 лв. за яйце
//Вход
//От конзолата се четат 3 реда:
//•	Брой козунаци - цяло число в интервала [0 … 99]
//•	Брой кори с яйца - цяло число в интервала [0 … 99]
//•	Килограми курабии - цяло число в интервала [0 … 99]
//Изход
//Да се отпечата на конзолата колко ще са разходите по приготвянето на обяда.
//Сумата да бъде форматирана до втория знак след десетичната запетая.

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