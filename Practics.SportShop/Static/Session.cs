using Practics.SportShop.Models;

namespace Practics.SportShop.Static;

public static class Session
{
    public static UserViewModel User { get; set; }
    public static bool IsGuest { get; set; } = false;
}