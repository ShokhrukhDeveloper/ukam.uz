using Backend.Uckam.Models;

namespace Backend.Uckam.Services.BookService;

public interface IBookService
{
    ValueTask<Result<Book>> GetAllBooksAsync();
    ValueTask<Result<Book>> GetByIdAsync(ulong id);
    ValueTask<Result<Book>> UpdateAsync(ulong id, User model, IFormFile image, IFormFile text);
    ValueTask<Result<Book>> CreateBookAsync(Book book, IFormFile file, IFormFile fileBook);
    ValueTask<Result<Book>> DeleteBookAsync(ulong id);
}