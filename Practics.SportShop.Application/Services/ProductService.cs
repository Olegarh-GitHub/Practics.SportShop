using Practics.SportShop.Application.Interfaces;
using Practics.SportShop.Application.Interfaces.Services;
using Practics.SportShop.Domain.Models;

namespace Practics.SportShop.Application.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productsRepository;

    public ProductService(IRepository<Product> productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public IQueryable<Product> GetProducts()
    {
        return _productsRepository.Read();
    }

    public Product GetById(int productId)
    {
        return _productsRepository.Read().FirstOrDefault(product => product.Id == productId);
    }
}