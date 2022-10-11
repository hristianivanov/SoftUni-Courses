namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstDocument = new StreamReader(firstInputFilePath),secondDocument = new StreamReader(secondInputFilePath))
            {
                StreamWriter writer = new StreamWriter(outputFilePath);
                string line = string.Empty;
                while (line != null)
                {
                    line = firstDocument.ReadLine();
                    if (line != null)
                        writer.WriteLine(line);

                    line = secondDocument.ReadLine();
                    if (line != null)
                        writer.WriteLine(line);
                }
                writer.Close();
            }
        }
    }
}
