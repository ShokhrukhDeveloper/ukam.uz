using Backend.Uckam.Dtos;
using Backend.Uckam.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Uckam.Controllers;

[ApiController]
[Route("api/controller")]

public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _service;

    public UsersController(ILogger<UsersController> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    public IActionResult UserCreate([FromForm] UserCreate dtos)
    {
        return Ok("saved");
    }
}