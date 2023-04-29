using System.ComponentModel.DataAnnotations.Schema;
using Practics.SportShop.Domain.Enums;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Domain.Models;

public class User : Entity
{
    public User(string username, string fullName, string password, UserRole role)
    {
        Username = username;
        FullName = fullName;
        Password = password;
        Role = role;
    }

    [Column("username")] public string Username { get; set; }

    [Column("full_name")] public string FullName { get; set; }

    [Column("password")] public string Password { get; set; }

    [Column("role")] public UserRole Role { get; set; }

    public List<Order> Orders { get; set; } = new();
    
    public User() { }
}