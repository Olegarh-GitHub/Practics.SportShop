using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Practics.SportShop.Application.Interfaces.Inputs;

namespace Practics.SportShop.Models.Inputs;

public class AuthorizeInput : IAuthorizeInput
{
    [DisplayName("Имя пользователя (логин)")] public string Username { get; set; }

    [DisplayName("Пароль")] public string Password { get; set; }
}