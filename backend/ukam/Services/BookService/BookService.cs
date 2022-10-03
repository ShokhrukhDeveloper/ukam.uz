using Backend.Uckam.Models;

namespace Backend.Uckam.Services.BookService;

public partial class BookService : IBookService
{
    public ValueTask<Result<Book>> CreateBookAsync(Book book, IFormFile file)
    {
        throw new NotImplementedException();
    }
}