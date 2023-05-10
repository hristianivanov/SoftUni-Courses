using System;

public class Program
{
    public static void Main()
    {
        int pair1Low = int.Parse(Console.ReadLine());
        int pair2Low = int.Parse(Console.ReadLine());
        int pair1High = int.Parse(Console.ReadLine()) + pair1Low;
        int pair2High = int.Parse(Console.ReadLine()) + pair2Low;

        for (int first = pair1Low; first <= pair1High; first++)
            for (int second = pair2Low; second <= pair2High; second++)
            {
                bool bothAreSimple = true;
                for (int div = 2; div <= first / 2; div++)
                    if (first % div == 0) bothAreSimple = false;
                for (int div = 2; div <= second / 2; div++)
                    if (second % div == 0) bothAreSimple = false;
                if (bothAreSimple) Console.WriteLine("{0}{1}", first, second);
            }
    }
}