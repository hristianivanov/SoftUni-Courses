namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> bytes = new List<byte>();

            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                while (!reader.EndOfStream)
                {
                    bytes.Add(byte.Parse(reader.ReadLine()));
                }
            }

            byte[] binaryFileBytes = File.ReadAllBytes(binaryFilePath);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (byte binaryFileByte in binaryFileBytes)
                {
                    if (bytes.Contains(binaryFileByte))
                    {
                        writer.Write(binaryFileByte);
                    }
                }
            }
        }
    }
}
