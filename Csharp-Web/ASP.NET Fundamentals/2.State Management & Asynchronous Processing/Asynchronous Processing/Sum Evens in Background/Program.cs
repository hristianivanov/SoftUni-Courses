namespace Sum_Evens_in_Background
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1, end = 1000000000;

            long sum = 0;

            Task.Run(() =>
            {
                for (long i = start; i <= end; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;   
                    }
                }
            });


            while (true)
            {
                var line = Console.ReadLine();

                if (line == "exit")
                    return;
                if (line == "show")
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}