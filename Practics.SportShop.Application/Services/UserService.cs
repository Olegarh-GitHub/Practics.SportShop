using Practics.SportShop.Application.Interfaces;
using Practics.SportShop.Application.Interfaces.Inputs;
using Practics.SportShop.Application.Interfaces.Services;
using Practics.SportShop.Domain.Enums;
using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _usersRepository;

    public UserService(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<bool> CreateAsync(ISignUpInput input)
    {
        string username = input.Username;
        string password = input.Password;
        string fullName = input.FullName;
        UserRole role = input.Role;

        var user = new User(username, fullName, password, role);

        try
        {
            await _usersRepository.InsertAsync(user);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public IQueryable<User> GetUsers()
    {
        return _usersRepository.Read();
    }

    public User GetById(int userId)
    {
        return _usersRepository.Read().FirstOrDefault(user => user.Id == userId);
    }

    public User GetByUsernameAndPassword(string username, string password)
    {
        User user = _usersRepository
            .Read()
            .FirstOrDefault
            (
                user => user.Username == username && 
                        user.Password == password
            );

        return user;
    }

    public User GetByUsername(string username)
    {
        return _usersRepository.Read().FirstOrDefault(user => user.Username == username);
    }
}