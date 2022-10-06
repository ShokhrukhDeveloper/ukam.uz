#pragma warning disable
using Backend.Uckam.Models;
using Backend.Uckam.Repositories;

namespace Backend.Uckam.Services.BookService;

public partial class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookService> _logger;

    public BookService(ILogger<BookService> logger, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _logger = logger ;
    }
    public async  ValueTask<Result<Book>> CreateBookAsync(Book book, IFormFile file,IFormFile bookFile)
    {
      var fileHelper = new FileHelper();
       string fileName = null;

      var fileBookHelper = new FileHelper();
       string fileBookName = null;

       if(file is not null)
        if(!fileHelper.FileValidateImage(file))
         return new("Image is invalid");

       if(bookFile is not null)
        if(!fileBookHelper.FileValidate(bookFile))
         return new("File is invalid");  

       if(file != null)
       fileName = fileHelper.WriteFileAsync(file , FileFolders.ConverImage).Result;

       if(bookFile != null)
       fileBookName = fileHelper.WriteFileAsync(bookFile , FileFolders.BookPath).Result;

       var createdEntity = new Backend.Uckam.Entities.Book(book, fileName, fileBookName ,ToEntityELanguage(book.Language), ToEntityEtype(book.Type), ToEntityECheckBook(book.CheckBook));

        try
        {
            var createdBook = await  _unitOfWork.Books.AddAsync(createdEntity);

            return new(true) { Data = ToModel(createdBook) };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(BookService)}");
            throw new("Couldn't create Book, Contact support", e);
        } 
    }

}