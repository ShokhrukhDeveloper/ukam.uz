#pragma warning disable

using Backend.Uckam.Dtos;
using Backend.Uckam.Models;
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

    [HttpPost]
    public async Task<IActionResult> UserCreate([FromForm] UserCreate dtos)
    {
        try
        {
            var createUserResult = await _userService.CreateAsync(ToModel(dtos));

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
        PasswordHash = dtos.Password,
        UserImage = dtos.UserImage,
        Balance = dtos.Balance ?? 0.0,
        Block = dtos.Block ?? false,
        Language = ToELanguageModel(dtos.Language ?? Dtos.ELanguage.Uzb),
        Role = ToERoleModel(dtos.Role ?? Dtos.ERole.User),
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