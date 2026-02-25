namespace LibrarySystem.Api.Domain.Entities;


public class Loan
{
    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
}
