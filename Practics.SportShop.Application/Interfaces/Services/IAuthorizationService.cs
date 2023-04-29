using Practics.SportShop.Application.Interfaces.Inputs;
using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Application.Interfaces.Services;

public interface IAuthorizationService
{
    public User Authorize(IAuthorizeInput input);
    public Task<bool> SignUpAsync(ISignUpInput input);
}