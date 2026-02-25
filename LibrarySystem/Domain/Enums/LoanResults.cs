namespace LibrarySystem.Api.Domain.Enums;


public enum LoanResult
{
    Success,
    NoBooks,
    NoUsers,
    InvalidBookId,
    InvalidUserId,
    BookUnavailable
}
