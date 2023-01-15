namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));

        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int cnt = 0;
                string line = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                Regex regex = new Regex(@"[-,.?!]");
                while ((line = reader.ReadLine()) != null)
                {
                    if (cnt % 2 == 0)
                    {
                        line = regex.Replace(line, "@");
                        var reverse = line.Split().Reverse();
                        stringBuilder.AppendLine(string.Join(" ",reverse));
                    }
                    cnt++;
                }
                return stringBuilder.ToString();
            }
        }


    }
}
