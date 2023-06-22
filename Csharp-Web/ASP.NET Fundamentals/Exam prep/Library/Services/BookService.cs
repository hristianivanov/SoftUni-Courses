using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await this.context.Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<MyAllBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await this.context.Books
                .Where(b => b.UsersBooks.Any(a => a.CollertorId == userId))
                .Select(b => new MyAllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await context.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await this.context.IdentityUsersBooks
                .AnyAsync(ub => ub.CollertorId == userId && ub.BookId == book.Id);

            if (alreadyAdded == false)
            {
                var userBook = new IdentityUserBook
                {
                    CollertorId = userId,
                    BookId = book.Id,
                };

                await context.IdentityUsersBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
            }
        }
    }
}
