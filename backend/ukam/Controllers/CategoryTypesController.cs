using Backend.Uckam.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Uckam.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryTypesController : ControllerBase
{
    private readonly ILogger<CategoryTypesController> _logger;
    private readonly ICategoryTypeService _service;

    public CategoryTypesController(ILogger<CategoryTypesController> logger, ICategoryTypeService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetTypes() 
    {
        try
        {
            var getTypes = await _service.GetAllAsync();

            if (!getTypes.IsSuccess)
                return BadRequest(new { ErrorMessage = getTypes.ErrorMessage });

            return Ok(getTypes);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromQuery] ulong categoryId, [FromQuery] ulong creatorId, [FromForm] string name)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var createTypeResult = await _service.CreateCategoryType(categoryId, creatorId, name);
        try
        {
            if (!createTypeResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createTypeResult.ErrorMessage });

            return Ok(createTypeResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
}