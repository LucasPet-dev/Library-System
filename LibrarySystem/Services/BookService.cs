using LibrarySystem.Api.Domain.Entities;
using LibrarySystem.Api.Infrastructure.Persistence;

namespace LibrarySystem.Api.Services;

public class BookService
{
    private readonly JsonDataStore<Book> _store =
        new("books.json");

    public List<Book> GetAll() => _store.GetAll();

    public Book Add(Book book)
    {
        var books = _store.GetAll();

        book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;

        books.Add(book);

        _store.SaveAll(books);

        return book;
    }

    public Book? GetById(int id)
    {
        return _store.GetAll()
                     .FirstOrDefault(b => b.Id == id);
    }

    public void Update(Book book)
    {
        var books = _store.GetAll();
        var index = books.FindIndex(b => b.Id == book.Id);

        if (index >= 0)
        {
            books[index] = book;
            _store.SaveAll(books);
        }
    }

    public bool HasBooks() => _store.GetAll().Any();
}
