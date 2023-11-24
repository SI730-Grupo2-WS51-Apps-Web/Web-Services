using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IProductImageRepository
{
    Task<IEnumerable<ProductImage>> ListAsync();
    Task AddAsync(ProductImage productImage);
    Task<ProductImage> FindByIdAsync(int id);
}