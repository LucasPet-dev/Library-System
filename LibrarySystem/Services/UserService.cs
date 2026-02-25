using LibrarySystem.Api.Domain.Entities;
using LibrarySystem.Api.Infrastructure.Persistence;

namespace LibrarySystem.Api.Services;

public class UserService
{
    private readonly JsonDataStore<User> _store =
        new("users.json");

    public List<User> GetAll() => _store.GetAll();

    public User Add(User user)
    {
        var users = _store.GetAll();

        user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;

        users.Add(user);

        _store.SaveAll(users);

        return user;
    }

    public User? GetById(int id)
    {
        return _store.GetAll()
                     .FirstOrDefault(u => u.Id == id);
    }

    public bool HasUsers() => _store.GetAll().Any();
}
