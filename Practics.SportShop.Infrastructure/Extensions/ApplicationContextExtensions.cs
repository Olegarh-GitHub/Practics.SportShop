using Microsoft.EntityFrameworkCore;
using Practics.SportShop.Domain.Models;
using Practics.SportShop.Infrastructure.Constants;

namespace Practics.SportShop.Infrastructure.Extensions;

public static class ApplicationContextExtensions
{
    public static void ConfigureIssuePoint(this ModelBuilder builder)
    {
        builder.Entity<IssuePoint>().ToTable(SportShopTables.ISSUE_POINT_TABLENAME);
        
        builder.Entity<IssuePoint>()
            .Property(selector => selector.Id)
            .HasColumnName("id");

        builder.Entity<IssuePoint>()
            .HasMany(selector => selector.Orders)
            .WithOne(selector => selector.IssuePoint)
            .HasForeignKey(selector => selector.IssuePointId);
    }

    public static void ConfigureProduct(this ModelBuilder builder)
    {
        builder.Entity<Product>().ToTable(SportShopTables.PRODUCT_TABLENAME);

        builder.Entity<Product>()
            .Property(selector => selector.Id)
            .HasColumnName("id");

        builder.Entity<Product>()
            .HasMany(selector => selector.Orders)
            .WithMany(selector => selector.Products)
            .UsingEntity<OrderProduct>(configure =>
            {
                configure.ToTable(SportShopTables.ORDER_PRODUCT_TABLENAME);
                
                configure
                    .Property(selector => selector.Id)
                    .HasColumnName("id");
                
                configure.HasOne(orderProduct => orderProduct.Order);
                configure.HasOne(orderProduct => orderProduct.Product);
            });
    }

    public static void ConfigureOrder(this ModelBuilder builder)
    {
        builder.Entity<Order>().ToTable(SportShopTables.ORDER_TABLENAME);
        
        builder.Entity<Order>()
            .Property(selector => selector.Id)
            .HasColumnName("id");
    }

    public static void ConfigureUser(this ModelBuilder builder)
    {
        builder.Entity<User>().ToTable(SportShopTables.USER_TABLENAME);

        builder.Entity<User>()
            .Property(selector => selector.Id)
            .HasColumnName("id");

        builder.Entity<User>()
            .HasMany(selector => selector.Orders)
            .WithOne(selector => selector.User)
            .HasForeignKey(selector => selector.UserId);
    }
}