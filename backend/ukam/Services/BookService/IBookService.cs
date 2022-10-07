using Backend.Uckam.Models;

namespace Backend.Uckam.Services.BookService;

public interface IBookService
{
    ValueTask<Result<Book>> CreateBookAsync(Book book, IFormFile file, IFormFile fileBook);
    ValueTask<Result<Book>> DeleteBookAsync(ulong id);
    ValueTask<Result<List<Book>>> GetAllBook();
}