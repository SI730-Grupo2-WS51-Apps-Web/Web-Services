using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IProductPerOrderService
{
    Task<IEnumerable<ProductPerOrder>> ListAsync();
    Task<ProductPerOrderResponse> SaveAsync(ProductPerOrder productperorder);
    Task<ProductPerOrderResponse> UpdateAsync(int id, ProductPerOrder productperorder);
    Task<ProductPerOrderResponse> DeleteAsync(int id);
}

