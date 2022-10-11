namespace OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                int cnt = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    cnt++;
                    if (cnt % 2 == 0)
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilePath,true))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
