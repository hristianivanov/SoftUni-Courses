using System;

namespace Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Constant for the capacity 
            const int CAPACITY = 255;
            int nLines = int.Parse(Console.ReadLine());
            int totalQuantity = CAPACITY;

            for (int i = 0; i < nLines; i++)
            {
                int currQuantity = int.Parse(Console.ReadLine());
                if (totalQuantity - currQuantity >= 0)
                {
                    totalQuantity -= currQuantity;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            int totalFieldQuntitiy = CAPACITY - totalQuantity;
            Console.WriteLine(totalFieldQuntitiy);
        }
    }
}
