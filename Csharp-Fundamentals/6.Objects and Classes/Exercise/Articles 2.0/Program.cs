using System;
using System.Collections.Generic;

namespace Articles_2._0
{
    internal class Program
    {
        public class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ");

                Article article = new Article(input[0], input[1], input[2]);

                articles.Add(article);  
            }
            
            string command = Console.ReadLine();

            foreach (var item in articles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
