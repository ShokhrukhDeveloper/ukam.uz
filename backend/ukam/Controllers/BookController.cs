#pragma warning disable
using Backend.Uckam.Dtos;
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
    

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromForm]BookCreate dtos)
    {
        _logger.LogInformation("Post methodiga kirdi");
        
         try
        {
            _logger.LogInformation("try catch ichiga kirdi.");
            var createBookResult = await _bookService.CreateBookAsync(ToModel(dtos), dtos.ConverImage);
            _logger.LogInformation("1111");

            if (!createBookResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createBookResult.ErrorMessage });

            return Ok(createBookResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
}