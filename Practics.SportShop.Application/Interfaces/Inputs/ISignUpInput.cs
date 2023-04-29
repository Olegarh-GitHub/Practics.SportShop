using Practics.SportShop.Domain.Enums;

namespace Practics.SportShop.Application.Interfaces.Inputs;

public interface ISignUpInput
{
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public string FullName { get; set; } 
}