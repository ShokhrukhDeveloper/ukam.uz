#pragma warning disable
using Backend.Uckam.data;
using Backend.Uckam.Dtos;
using Backend.Uckam.Repositories;
using Backend.Uckam.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Uckam.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("multipart/form-data")]
public partial class BookController:ControllerBase
{
    
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;
    private readonly AppDbContext _context;
    private readonly IBookRepository _repo;

    public BookController(ILogger<BookController> logger, IBookService bookService, AppDbContext context)
    {
        _logger = logger;
        _bookService = bookService ;
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromForm]BookCreate dtos)
    {
        _logger.LogInformation("Post methodiga kirdi");
        
         try
        {
            _logger.LogInformation("try catch ichiga kirdi.");
            var createBookResult = await _bookService.CreateBookAsync(ToModel(dtos), dtos.ConverImage, dtos.BookFile);
            _logger.LogInformation("1111");

            if (!createBookResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createBookResult.ErrorMessage });

            return Ok(createBookResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
        // remove this line next repository 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(ulong id)
    {
        var result = await _bookService.DeleteBookAsync(id);

        if(!result.IsSuccess) return BadRequest(new { ErrorMessage = result.ErrorMessage });

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBook()
    {
         try
        {
            var booksReult = await _bookService.GetAllBook();

            if(!booksReult.IsSuccess) return NotFound(new { ErrorMessage = booksReult.ErrorMessage });

            return Ok(booksReult.Data?.Select(ToDto));
        }
        catch (Exception e)
        {
             return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook([FromRoute] ulong id, [FromForm] BookUpdate dtos)
    {
       try
       {
          var createdBook = await _bookService.UpdateBookAsync(id, ToModel(dtos), dtos.ConverImage, dtos.BookFile);

          if (!createdBook.IsSuccess)
                return BadRequest(new { ErrorMessage = createdBook.ErrorMessage });

            return Ok(createdBook);
       }
       catch (Exception e)
       {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
       }
    }
    
}