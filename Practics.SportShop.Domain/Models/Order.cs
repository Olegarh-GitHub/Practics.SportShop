using System.ComponentModel.DataAnnotations.Schema;
using Practics.SportShop.Domain.Enums;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Domain.Models;

public class Order : Entity
{
    [Column("customer_full_name")] public string CustomerFullName { get; set; }

    [Column("status")] public OrderStatus Status { get; set; }

    [Column("order_date")] public DateTime OrderDate { get; set; }

    [Column("close_date")] public DateTime? CloseDate { get; set; }

    [Column("receive_code")] public int ReceiveCode { get; set; }

    [Column("issue_point_id")] public int IssuePointId { get; set; }

    [Column("user_id")] public int UserId { get; set; }

    public User User { get; set; }
    public IssuePoint IssuePoint { get; set; }
    public List<Product> Products { get; set; }
}