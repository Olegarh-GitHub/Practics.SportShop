using Practics.SportShop.Application.Interfaces;
using Practics.SportShop.Application.Interfaces.Services;
using Practics.SportShop.Application.Services;
using Practics.SportShop.Domain.Models;
using Practics.SportShop.Infrastructure.Contexts;
using Practics.SportShop.Infrastructure.Repositories;

namespace Practics.SportShop.Configuration;

public static class DependencyInjection
{
    public static void ConfigureApplicationDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRepository<IssuePoint>, Repository<ApplicationContext, IssuePoint>>();
        services.AddTransient<IRepository<Order>, Repository<ApplicationContext, Order>>();
        services.AddTransient<IRepository<Product>, Repository<ApplicationContext, Product>>();
        services.AddTransient<IRepository<User>, Repository<ApplicationContext, User>>();

        services.AddTransient<IAuthorizationService, AuthorizationService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IUserService, UserService>();
    }
}