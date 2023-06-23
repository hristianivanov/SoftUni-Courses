namespace Sum_Evens_in_Range
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command is null or "quit" or "end")
                    break;

                if (command == "show")
                {
                    var result = SumAsync(1,10000);
                    Console.WriteLine(result);
                }
            }
        }

        private static long SumAsync(int start,int end)
        {
            return Task.Run(() =>
            {
                long sum = 0;

                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }

                return sum;
            }).Result;
        }
    }
}