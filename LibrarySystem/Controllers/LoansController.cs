using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Api.Domain.Enums;
using LibrarySystem.Api.Services;

namespace LibrarySystem.Api.Controllers;

[ApiController]
[Route("api/loans")]
public class LoansController : ControllerBase
{
    private readonly LoanService _service;

    public LoansController(LoanService service)
    {
        _service = service;
    }

    [HttpPost("borrow")]
    public IActionResult Borrow(int bookId, int userId)
    {
        var result = _service.Borrow(bookId, userId);

        return result switch
        {
            LoanResult.Success => Ok("Book borrowed successfully."),
            LoanResult.NoBooks => BadRequest("No books registered."),
            LoanResult.NoUsers => BadRequest("No users registered."),
            LoanResult.InvalidBookId => NotFound("Invalid book id."),
            LoanResult.InvalidUserId => NotFound("Invalid user id."),
            LoanResult.BookUnavailable => BadRequest("Book unavailable."),
            _ => BadRequest("Operation failed.")
        };
    }

    [HttpPost("return")]
    public IActionResult Return(int bookId)
    {
        var result = _service.Return(bookId);

        return result == LoanResult.Success
            ? Ok("Book returned.")
            : NotFound("Invalid book id.");
    }
}
