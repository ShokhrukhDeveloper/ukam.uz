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

    [HttpPut("{id}")]
    public async Task<IActionResult> UserUpdate([FromRoute] ulong id, [FromForm] UserUpdate dtos)
    {
        try
        {
            var createUserResult = await _userService.UpdateAsync(id,ToModel(dtos), dtos.Image);

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
        _logger.LogInformation("all of them are good ===============");

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
        // remove this line next repository 
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
        Balance = dtos.Balance ?? 0.0,
        Language = ToELanguageModel(dtos.Language ?? Dtos.ELanguage.Uzb),
    };
    private Models.User ToModel(UserUpdate dtos)
    => new()
    {
        FirstName = dtos.FirstName,
        LastName = dtos.LastName,
        UserName = dtos.UserName,
        PasswordHash = dtos.Password,
        Balance = dtos.Balance ?? 0.0,
        Language = ToELanguageModel(dtos.Language ?? Dtos.ELanguage.Uzb),
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