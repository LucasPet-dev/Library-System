using LibrarySystem.Api.Domain.Entities;
using LibrarySystem.Api.Domain.Enums;
using LibrarySystem.Api.Infrastructure.Persistence;

namespace LibrarySystem.Api.Services;

public class LoanService
{
    private readonly BookService _bookService;
    private readonly UserService _userService;
    private readonly JsonDataStore<Loan> _loanStore =
        new("loans.json");

    public LoanService(BookService bookService,
                       UserService userService)
    {
        _bookService = bookService;
        _userService = userService;
    }

    public LoanResult Borrow(int bookId, int userId)
    {
        if (!_bookService.HasBooks())
            return LoanResult.NoBooks;

        if (!_userService.HasUsers())
            return LoanResult.NoUsers;

        var book = _bookService.GetById(bookId);
        if (book == null)
            return LoanResult.InvalidBookId;

        var user = _userService.GetById(userId);
        if (user == null)
            return LoanResult.InvalidUserId;

        if (!book.IsAvailable)
            return LoanResult.BookUnavailable;

        book.Borrow();
        _bookService.Update(book);

        var loans = _loanStore.GetAll();
        loans.Add(new Loan
        {
            BookId = bookId,
            UserId = userId
        });

        _loanStore.SaveAll(loans);

        return LoanResult.Success;
    }

    public LoanResult Return(int bookId)
    {
        var book = _bookService.GetById(bookId);

        if (book == null)
            return LoanResult.InvalidBookId;

        book.Return();
        _bookService.Update(book);

        return LoanResult.Success;
    }
}
