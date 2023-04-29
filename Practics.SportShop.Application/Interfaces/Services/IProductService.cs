using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Application.Interfaces.Services;

public interface IProductService
{
    public IQueryable<Product> GetProducts();
    public Product GetById(int productId);
}