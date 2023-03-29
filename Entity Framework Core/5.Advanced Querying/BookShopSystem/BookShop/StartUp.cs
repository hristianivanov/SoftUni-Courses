namespace BookShop
{
    using Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var validRestriction = Enum.TryParse<AgeRestriction>(command, true, out AgeRestriction ageRestriction);

            if (!validRestriction) 
                return string.Empty;

            var booksInfo = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);

        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] booksInfo = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
                            b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            string[] booksInfo = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksInfo = context.Books
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(c => c.ToLower())
                                       .ToArray();
            var booksInfo = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            string[] bookInfo = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, bookInfo);
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsInfo = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authorsInfo);
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitleInfo = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitleInfo);
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksInfo = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var authorsCopiesInfo = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(b => b.TotalCopies);

            foreach (var author in authorsCopiesInfo)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesWithProfit = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                    .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .AsEnumerable()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var category in categoriesWithProfit)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryWithThreeRecentBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        TitleName = b.Book.Title,
                        ReleaseDate = b.Book.ReleaseDate!.Value.Year
                    })
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var category in categoryWithThreeRecentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.TitleName} ({book.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            //Materializing the query doesn't detach entities from Change Tracker
            var booksReleaseBefore2010 = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate!.Value.Year < 2010)
                .ToArray();

            foreach (var book in booksReleaseBefore2010)
                book.Price += 5;
            //context.BulkUpdate(booksReleaseBefore2010);
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var bookToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(bookToRemove);
            context.SaveChanges();

            return bookToRemove.Count();
        }
    }
}


