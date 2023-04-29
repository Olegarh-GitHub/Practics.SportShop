using Microsoft.EntityFrameworkCore;
using Practics.SportShop.Infrastructure.Contexts;

namespace Practics.SportShop.Configuration.ORM;

public static class EntityFrameworkConfiguration
{
    public static void ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("sport_shop");
        
        services.AddDbContext<ApplicationContext>
        (
            options => options.UseNpgsql(connectionString),
            ServiceLifetime.Transient
        );
    }
}