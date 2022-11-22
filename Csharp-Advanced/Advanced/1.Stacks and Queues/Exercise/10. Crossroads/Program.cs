using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queuedCars = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int totalCarsPassed = 0;
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green" && queuedCars.Count > 0)
                {
                    string currentCar = queuedCars.Dequeue();
                    Queue<char> passingCarChars = new Queue<char>(currentCar);

                    // Looping through the seconds of the green light duration
                    for (int i = 0; i < greenLightDuration; i++)
                    {
                        if (passingCarChars.Count > 0)
                        {
                            passingCarChars.Dequeue();
                            if (passingCarChars.Count == 0) totalCarsPassed++;
                        }
                        else if (queuedCars.Count > 0)
                        {
                            currentCar = queuedCars.Dequeue();
                            foreach (char ch in currentCar)
                                passingCarChars.Enqueue(ch);
                            passingCarChars.Dequeue();
                        }
                    }

                    // Looping through the seconds of the free window duration
                    for (int i = 0; i < freeWindowDuration; i++)
                    {
                        if (passingCarChars.Count > 0)
                        {
                            passingCarChars.Dequeue();
                            if (passingCarChars.Count == 0) totalCarsPassed++;
                        }
                    }

                    // Checking if there's still a car on the crossroad
                    if (passingCarChars.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {passingCarChars.Peek()}.");
                        return;
                    }
                }

                else if (input != "green")
                {
                    queuedCars.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
