namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using(StreamReader reader = new StreamReader(wordsFilePath))
            {
                Dictionary<string,int> keyValuePairs = new Dictionary<string,int>();
                var words = reader.ReadToEnd().Split();
                for (int i = 0; i < words.Length; i++)
                {
                    keyValuePairs.Add(words[i],1);
                }
                
                using (StreamReader text = new StreamReader(textFilePath))
                {
                    var data = text.ReadToEnd()
                        .Split(new char[] { '.', ',', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToList();

                    foreach (var item in data)
                    {
                        if (keyValuePairs.ContainsKey(item))
                        {
                            keyValuePairs[item]++;
                        }
                    }
                }
                using(StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var item in keyValuePairs.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
