using Library.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var books = await bookService.GetMyBooksAsync(userId); 
            return View(books);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }
    }
}
