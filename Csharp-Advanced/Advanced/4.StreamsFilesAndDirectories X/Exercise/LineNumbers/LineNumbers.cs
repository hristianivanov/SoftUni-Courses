namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            Regex signs = new Regex(@"[^\s\w]");
            Regex letters = new Regex(@"[\w]");
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                int cnt = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    cnt++;
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        MatchCollection matchesSigns = signs.Matches(line);
                        MatchCollection matchesLetters = letters.Matches(line);
                        writer.WriteLine($"Line {cnt}: {line} ({matchesLetters.Count})({matchesSigns.Count})");
                    }
                }
            }
        }
    }
}
