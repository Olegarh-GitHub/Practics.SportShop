using Microsoft.EntityFrameworkCore;
using Practics.SportShop.Domain.Models;
using Practics.SportShop.Infrastructure.Extensions;

namespace Practics.SportShop.Infrastructure.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<IssuePoint> IssuePoints { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureOrder();
        modelBuilder.ConfigureIssuePoint();
        modelBuilder.ConfigureProduct();
        modelBuilder.ConfigureUser();
    }
}