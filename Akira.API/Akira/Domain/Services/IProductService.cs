using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int id, Product product);
    Task<ProductResponse> DeleteAsync(int id);
}

