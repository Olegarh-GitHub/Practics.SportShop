using Practics.SportShop.Application.Interfaces.Inputs;
using Practics.SportShop.Application.Interfaces.Services;
using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Application.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserService _userService;

    public AuthorizationService(IUserService userService)
    {
        _userService = userService;
    }

    public User Authorize(IAuthorizeInput input)
    {
        string username = input.Username;
        string password = input.Password;

        return _userService.GetByUsernameAndPassword(username, password);
    }

    public async Task<bool> SignUpAsync(ISignUpInput input)
    {
        string username = input.Username;

        User existedUser = _userService.GetByUsername(username);

        if (existedUser != null)
            return false;

        return await _userService.CreateAsync(input);
    }
}