using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByIdAsync(int id);
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> ListBySubcategoryIdAsync(int subcategoryId);
    Task<IEnumerable<Product>> ListByFranchiseIdAsync(int franchiseId);
    Task<IEnumerable<Product>> ListByPriceBetweenAsync(float min, float max);
    Task<IEnumerable<Product>> ListByStockAvaliableAsync();
}