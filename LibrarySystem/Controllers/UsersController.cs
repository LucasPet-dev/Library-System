using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Api.Domain.Entities;
using LibrarySystem.Api.Services;

namespace LibrarySystem.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        var created = _service.Add(user);
        return Ok(created);
    }
}
