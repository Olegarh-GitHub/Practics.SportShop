using Practics.SportShop.Domain.Interfaces;

namespace Practics.SportShop.Domain.Models.Base;

public abstract class Entity : IEntity
{
    public int Id { get; set; }
}