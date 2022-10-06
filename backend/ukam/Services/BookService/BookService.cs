#pragma warning disable
using System.Collections.Generic;
using Backend.Uckam.Models;
using Backend.Uckam.Repositories;
using Microsoft.EntityFrameworkCore;

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
         return new("File is invalid");

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

    public async  ValueTask<Result<Book>> DeleteBookAsync(ulong id)
    {
        try
        {
             var existingBook =  _unitOfWork.Books.GetById(id);

             if(existingBook is null) return new("Category with given Id Not Found");

             var result =  await _unitOfWork.Books.Remove(existingBook);

             return new(true) { Data=ToModel(result)};
        }
        catch (Exception e)
        {
           _logger.LogError($"Error occured at {nameof(BookService)}", e);
            throw new(" Contact support.", e);
        }
        
    }

    public async ValueTask<Result<List<Book>>> GetAllBookAsync()
    {
        try
        {
            var existBooks =  _unitOfWork.Books.GetAll();
            _logger.LogInformation("Malumotlarni oldi");
            if(existBooks is null) return new("No users found. Contact support.");
            _logger.LogInformation("tekshirib boldi");
            var filteredBooks = await existBooks.Select(u => ToModel(u)).ToListAsync();
            _logger.LogInformation("jonatishga tayyorlanyabdi");
            return new(true) { Data = filteredBooks };
            _logger.LogInformation("Jonatdi");

        }
        catch (Exception e)
        {
               _logger.LogError($"Error occured at {nameof(BookService)}", e);
            throw new("Couldn't get Books. Contact support.", e);
        }
    }

    public async ValueTask<Result<Book>> UpdateBookAsync(ulong id, Book book, IFormFile file, IFormFile fileBook)
    {
       string fileName = null;
       string fileName2 = null;

       var existingBook = _unitOfWork.Books.GetById(id);
       var fileHelper = new FileHelper();
       var fileHelper2 = new FileHelper();

       if(existingBook is null)   
            return new("User with given ID not found.");

       _logger.LogInformation("ImageFileni tekshiryabdi.");    
            
        if(file is not null)
            if(!fileHelper.FileValidateImage(file));
               return new("ImageFile is Invalid");

        if(existingBook.ConverImage != null)
           if(!fileHelper.DeleteFileByName(existingBook.ConverImage));
              return new("ImageFile is not avialable");   

        if (file != null)
            fileName = await fileHelper.WriteFileAsync(file, FileFolders.ConverImage); 

        _logger.LogInformation("Fileni tekshiryabdi.");

        if(fileBook is not null)
            if(!fileHelper2.FileValidate(fileBook));
               return new("File is Invalid");   
                
        if(existingBook.BookPath != null)
            if(!fileHelper2.DeleteFileByName(existingBook.BookPath));
               return new("File is not avialable");

        if(fileBook != null)
            fileName2 = await fileHelper2.WriteFileAsync(fileBook, FileFolders.BookPath); 


        existingBook.BookName = book.BookName;
        existingBook.Author = book.Author;
        existingBook.Establish = book.Establish;
        existingBook.Content = book.Content;
        existingBook.ConverImage = fileName;
        existingBook.Price = book.Price;
        existingBook.Type = ToEntityEtype(book.Type);
        existingBook.Language = ToEntityELanguage(book.Language);
        existingBook.CheckBook = ToEntityECheckBook(book.CheckBook);
        existingBook.CategoryId = book.CategoryId;
        existingBook.UserId = book.UserId;

        try
        {
            var createdBook =  await _unitOfWork.Books.Update(existingBook);

            return new(true) { Data = ToModel(createdBook) };
        }
        catch (Exception e)
        {
             _logger.LogInformation($"Error occured at {nameof(BookService)}");
            throw new("Couldn't create Book, Contact support", e);
        }
    }
}