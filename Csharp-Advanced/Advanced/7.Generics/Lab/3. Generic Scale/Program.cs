using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(3, 5);
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
