using System;

namespace Articles
{
    internal class Program
    {
        public class Article
        {
            public Article()
            {

            }
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public static void Edit(string content, Article article)
            {
                article.Content = content;
            }

            public static void ChangeAuthor(string author, Article article)
            {
                article.Author = author;
            }

            public static void Rename(string title, Article article)
            {
                article.Title = title;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(", ");
            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] action = Console.ReadLine().Split(": ");
                switch (action[0])
                {
                    case "Edit": Article.Edit(action[1], article); break;
                    case "ChangeAuthor": Article.ChangeAuthor(action[1], article); break;
                    case "Rename": Article.Rename(action[1], article); break;
                    default:
                        break;
                }
            }
            Console.WriteLine(article);
        }
    }
}
