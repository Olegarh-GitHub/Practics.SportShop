using Practics.SportShop.Domain.Enums;
using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Models;

public class UserViewModel
{
    public UserViewModel() { }

    public UserViewModel(User user)
    {
        Id = user.Id;
        FullName = user.FullName;
        Role = user.Role;
    }
    
    public UserViewModel(string fullName, UserRole role)
    {
        FullName = fullName;
        Role = role;
    }

    public int Id { get; set; }
    public string FullName { get; set; }
    public UserRole Role { get; set; }
}