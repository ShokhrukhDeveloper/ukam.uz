using Microsoft.AspNetCore.Mvc;
using ukam.Dtos.CategoryDTOs;
using ukam.Services.CategoryService;

namespace ukam.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [Consumes("multipart/form-data")]
    public partial class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService,ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
// test file
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Dtos.Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Dtos.Error))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _categoryService.GetAllAsync();
                
                if(!result.IsSuccess)
                    return NotFound(new { ErrorMessage=result.ErrorMessage});

                return Ok(result);

            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
            }
        }

      [HttpPost]
      [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
      [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Dtos.Error))]
      [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Dtos.Error))]
        public async Task<IActionResult> CreateCategory([FromForm]CategoryCreate category)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest();
                var result = await _categoryService.
                    CreateCategory(new ()
                        {
                         Name=category.Name,
                         CreatorId=category.UserId
                        }, 
                         category.Image
                        );
                if(!result.IsSuccess)
                    return NotFound(result);
                return Ok(result);             

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
            }
        }
    }  


