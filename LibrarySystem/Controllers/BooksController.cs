using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Api.Domain.Entities;
using LibrarySystem.Api.Services;

namespace LibrarySystem.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly BookService _service;

    public BooksController(BookService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _service.GetById(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        var created = _service.Add(book);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }
}
