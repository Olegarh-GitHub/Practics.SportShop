using Practics.SportShop.Application.Interfaces.Inputs;
using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Application.Interfaces.Services;

public interface IUserService
{
    public Task<bool> CreateAsync(ISignUpInput input);
    public IQueryable<User> GetUsers();
    public User GetById(int userId);
    public User GetByUsernameAndPassword(string username, string password);
    public User GetByUsername(string username);
}