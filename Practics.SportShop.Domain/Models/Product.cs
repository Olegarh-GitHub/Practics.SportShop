using System.ComponentModel.DataAnnotations.Schema;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Domain.Models;

public class Product : Entity
{
    [Column("name")] public string Name { get; set; }

    [Column("description")] public string Description { get; set; }

    [Column("price")] public decimal Price { get; set; }

    [Column("discount")] public int Discount { get; set; }

    [Column("stocks")] public int Stocks { get; set; }

    [Column("image_path")] public string ImagePath { get; set; }

    public List<Order> Orders { get; set; }
}