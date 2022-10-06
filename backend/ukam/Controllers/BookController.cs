#pragma warning disable
using Backend.Uckam.Dtos;
using Backend.Uckam.Models;
using Backend.Uckam.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Uckam.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("multipart/form-data")]
public partial class BookController:ControllerBase
{
    
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService ;
    }

    [HttpGet]

    public async Task<IActionResult> GetBook()
    {
        try
        {
            var booksReult = await _bookService.GetAllBookAsync();

            if(!booksReult.IsSuccess) return NotFound(new { ErrorMessage = booksReult.ErrorMessage });

            return Ok(booksReult.Data?.Select(ToDto));
        }
        catch (Exception e)
        {
             return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook([FromRoute] ulong id, [FromForm] BookUpdate dtos)
    {
        try
        {
            var createBookResult = await _bookService.UpdateBookAsync(id, ToModel(dtos),dtos.ConverImage, dtos.BookPath);

            if (!createBookResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createBookResult.ErrorMessage });

            return Ok(createBookResult);


        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(ulong id)
    {
        var result = await _bookService.DeleteBookAsync(id);

        if(!result.IsSuccess) return BadRequest(new { ErrorMessage = result.ErrorMessage });

        return Ok(result);
    }

    
}