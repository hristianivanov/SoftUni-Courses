using System;

namespace Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double eps = 0.000001;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            bool output = Math.Abs(a - b) < eps;
            Console.WriteLine(output);

            //5.3           6.01         False
            //5.00000001    5.00000003   True
            //5.00000005    5.00000001   True
            //-0.0000007    0.00000007   True
            //- 4.999999   - 4.999998    False
            //4.999999      4.999998     False

        }
    }
}
