using Microsoft.AspNetCore.Mvc;
using ukam.Dtos.TypeDTO;
using ukam.Services.TypeService;
using Type = ukam.Models.Type;

namespace ukam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService typeService;

        public TypeController(ITypeService typeService)
        {
            this.typeService = typeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Type>))]
        public async Task<ActionResult<List<Type>>> Index()
        {
            var response = await typeService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeResponseDTO))]
        public async Task<ActionResult<TypeResponseDTO>> Create(TypeDTO dto)
        {
            var response = await typeService.AddAsync(dto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeResponseDTO))]
        public async Task<ActionResult<TypeResponseDTO>> Show(int id)
        {
            var response = await typeService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeResponseDTO))]
        public async Task<ActionResult<TypeResponseDTO>> Update(int id, TypeDTO dto)
        {
            var response = await typeService.UpdateAsync(id, dto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeResponseDTO))]
        public async Task<ActionResult<TypeResponseDTO>> Delete(int id)
        {
            var response = await typeService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
