using System.ComponentModel.DataAnnotations.Schema;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Domain.Models;

public class IssuePoint : Entity
{
    [Column("address")] public string Address { get; set; }

    public List<Order> Orders { get; set; } = new();
}