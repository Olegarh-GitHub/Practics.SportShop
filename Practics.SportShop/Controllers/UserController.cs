using Microsoft.AspNetCore.Mvc;
using Practics.SportShop.Application.Interfaces.Services;
using Practics.SportShop.Models;
using Practics.SportShop.Models.Inputs;
using Practics.SportShop.Static;

namespace Practics.SportShop.Controllers;

public class UserController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;

    public UserController(IAuthorizationService authorizationService, IUserService userService)
    {
        _authorizationService = authorizationService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View("UserSignUpView");
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpInput input)
    {
        var result = await _authorizationService.SignUpAsync(input);

        return result ? View("UserAuthorizeView") : View("Error");
    }

    [HttpGet]
    public IActionResult Authorize()
    {
        return View("UserAuthorizeView");
    }
    
    [HttpPost]
    public IActionResult Authorize(AuthorizeInput input)
    {
        var result = _authorizationService.Authorize(input);

        if (result is null) 
            return View("Error");

        Session.User = new UserViewModel(result);
        
        return RedirectToAction("Index", "Product", new { userId = result.Id });
    }

    [HttpGet]
    public IActionResult Exit()
    {
        Session.User = null;

        return View("UserAuthorizeView");
    }
}