using Library.ViewModels;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task<IEnumerable<MyAllBookViewModel>> GetMyBooksAsync(string userId);
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
    }
}
