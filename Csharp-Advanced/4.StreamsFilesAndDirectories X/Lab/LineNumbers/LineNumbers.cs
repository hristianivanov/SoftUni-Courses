namespace LineNumbers
{
    using System;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                int cnt=0;
                while ((line = reader.ReadLine()) != null)
                {
                    cnt++;
                    using(StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        writer.WriteLine($"{cnt}. {line}");
                    }
                }
            }
        }
    }
}
