using System.ComponentModel.DataAnnotations.Schema;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Domain.Models;

public class OrderProduct : Entity
{
    [Column("order_id")] public int OrderId { get; set; }
    public Order Order { get; set; }

    [Column("product_id")] public int ProductId { get; set; }
    public Product Product { get; set; }

    [Column("quantity")] public int Quantity { get; set; }
}