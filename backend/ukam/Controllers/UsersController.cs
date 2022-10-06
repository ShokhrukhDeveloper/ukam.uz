#pragma warning disable

using Backend.Uckam.Dtos;
using Backend.Uckam.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Uckam.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("multipart/form-data")]

public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;

    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]

    public async Task<IActionResult> GetUsers([FromQuery] UsersGetAllPagination pagination)
    {
        try
        {
            var usersResult = await _userService.GetAllPaginatedUsersAsync(pagination.Page, pagination.Limit);
            if (!usersResult.IsSuccess)
                return NotFound(new { ErrorMessage = usersResult.ErrorMessage });

            return Ok(usersResult?.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpGet]
    [Route("Admins")]

    public async Task<IActionResult> GetAdmins([FromForm] UsersGetAllPagination pagination)
    {
        try
        {
            var usersResult = await _userService.GetAllPaginatedAdminsAsync(pagination.Page, pagination.Limit);

            if (!usersResult.IsSuccess)
                return NotFound(new { ErrorMessage = usersResult.ErrorMessage });

            return Ok(usersResult?.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] ulong id)
    {
        try
        {
            var createUserResult = await _userService.GetByIdAsync(id);

            if (!createUserResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createUserResult.ErrorMessage });

            return Ok(createUserResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UserUpdate([FromRoute] ulong id, [FromForm] UserUpdate dtos)
    {
        try
        {
            var createUserResult = await _userService.UpdateAsync(id, ToModel(dtos), dtos.Image);

            if (!createUserResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createUserResult.ErrorMessage });

            return Ok(createUserResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }

    }

    [HttpPatch("Chage/{id}")]
    public async Task<IActionResult> ChangeUserOrAdmin([FromRoute] ulong id, [FromForm] ERole role)
    {
        try
        {
            var createUserResult = await _userService.ChangeUserOrAdminAsync(id, ToERoleModel(role));

            if (!createUserResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createUserResult.ErrorMessage });

            return Ok(createUserResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpPatch("block/{id}")]
    public async Task<IActionResult> UserBlock([FromRoute] ulong id, [FromQuery] bool block)
    {
        try
        {
            var createUserResult = await _userService.UserBlock(id, block);

            if (!createUserResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createUserResult.ErrorMessage });

            return Ok(createUserResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> UserCreate([FromForm] UserCreate dtos)
    {

        try
        {
            var createUserResult = await _userService.CreateAsync(ToModel(dtos), dtos.Image);

            if (!createUserResult.IsSuccess)
                return BadRequest(new { ErrorMessage = createUserResult.ErrorMessage });

            return Ok(createUserResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    private object? ToDto(object value)
    {
        throw new NotImplementedException();
    }

    private Models.User ToModel(UserCreate dtos)
    => new()
    {
        FirstName = dtos.FirstName,
        LastName = dtos.LastName,
        UserName = dtos.UserName,
        Password = dtos.Password,
        Balance = dtos.Balance ?? 0.0,
        Language = ToELanguageModel(dtos.Language ?? Dtos.ELanguage.Uzb),
    };
    private Models.User ToModel(UserUpdate dtos)
    => new()
    {
        FirstName = dtos.FirstName,
        LastName = dtos.LastName,
        UserName = dtos.UserName,
        Balance = dtos.Balance ?? 0.0,
        Language = ToELanguageModel(dtos.Language ?? Dtos.ELanguage.Uzb),
    };

    private Models.ERole ToRole(ERole role)
    => role switch
    {
        ERole.Admin => Models.ERole.Admin,
        ERole.SuperAdmin => Models.ERole.SuperAdmin,
        _ => Models.ERole.User,
    };

    private Models.ERole ToERoleModel(Dtos.ERole role)
    => role switch
    {
        Dtos.ERole.Admin => Models.ERole.Admin,
        Dtos.ERole.SuperAdmin => Models.ERole.SuperAdmin,
        _ => Models.ERole.User
    };

    private Models.ELanguage ToELanguageModel(Dtos.ELanguage language)
    => language switch
    {
        Dtos.ELanguage.Eng => Models.ELanguage.Eng,
        Dtos.ELanguage.Rus => Models.ELanguage.Rus,
        _ => Models.ELanguage.Uzb
    };
}