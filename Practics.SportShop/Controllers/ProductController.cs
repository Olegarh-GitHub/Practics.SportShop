using Microsoft.AspNetCore.Mvc;
using Practics.SportShop.Application.Interfaces.Services;
using Practics.SportShop.Models;
using Practics.SportShop.Models.Inputs;
using Practics.SportShop.Static;

namespace Practics.SportShop.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IUserService _userService;
    private UserViewModel _user;
    private bool _isGuest = false;

    public ProductController(IProductService productService, IUserService userService)
    {
        _productService = productService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index(int? userId = null, bool isGuest = false)
    {
        _isGuest = isGuest;
        Session.IsGuest = isGuest;

        if (userId.HasValue)
        {
            _user = Session.User;

            ViewBag.FullName = _user.FullName;
            ViewBag.LoggedIn = true;
        }

        var products = _productService.GetProducts().ToList();
        
        return View("ProductCatalogView", products);
    }

    [HttpPost]
    public IActionResult Index(ProductsDiscountFilterInput input)
    {
        var products = _productService.GetProducts();
        
        switch (input)
        {
            case ProductsDiscountFilterInput.All:
                break;
                
            case ProductsDiscountFilterInput.ZeroToTen:
                products = products.Where(product => product.Discount >= 0 && product.Discount < 10);
                
                break;
            
            case ProductsDiscountFilterInput.TenToFifteen:
                products = products.Where(product => product.Discount >= 10 && product.Discount < 15);

                break;
            case ProductsDiscountFilterInput.FromFifteen:
                products = products.Where(product => product.Discount >= 15);
                
                break;
            default:
                return View("ProductCatalogView", products.ToList());
        }
        
        return View("ProductCatalogView", products.ToList());
    }
}