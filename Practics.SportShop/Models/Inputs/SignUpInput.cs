using System.ComponentModel;
using Practics.SportShop.Application.Interfaces.Inputs;
using Practics.SportShop.Domain.Enums;

namespace Practics.SportShop.Models.Inputs;

public class SignUpInput : ISignUpInput
{
    [DisplayName("Ваше имя пользователя")]
    public string Username { get; set; }
    
    [DisplayName("Ваш пароль")]
    public string Password { get; set; }
    
    [DisplayName("Ваша роль в системе")]
    public UserRole Role { get; set; }
    
    [DisplayName("Ваше ФИО")]
    public string FullName { get; set; }
}