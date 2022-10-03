#pragma warning disable
using Backend.Uckam.Models;
using Backend.Uckam.Repositories;

namespace Backend.Uckam.Services.BookService;

public partial class BookService : IBookService
{
    private readonly ILogger<BookService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public BookService(ILogger<BookService> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger ;
        _unitOfWork = unitOfWork;
    }
    public async ValueTask<Result<Book>> CreateBookAsync(Book book, IFormFile? file)
    {
        var fileHelper = new FileHelper();
       string fileName = null;

       if(file is not null)
        if(!fileHelper.FileValidateImage(file))
         return new("File is invalid");

       if(file != null)
       fileName = fileHelper.WriteFileAsync(file , FileFolders.ConverImage).Result;

       var createdEntity = new Backend.Uckam.Entities.Book(book, fileName, ToEntityELanguage(book.Language), ToEntityEtype(book.Type), ToEntityECheckBook(book.CheckBook));

        try
        {
            _logger.LogInformation("BookServicedagi try catch ichiga kirdi.");
            var createdBook = await  _unitOfWork.Books.AddAsync(createdEntity);

            return new(true) { Data = ToModel(createdBook) };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(BookService)}");
            throw new("Couldn't create User, Contact support", e);
        } 

    }
}