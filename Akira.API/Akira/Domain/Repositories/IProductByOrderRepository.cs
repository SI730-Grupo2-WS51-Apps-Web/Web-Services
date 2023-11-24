using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IProductPerOrderRepository
{
    Task<IEnumerable<ProductPerOrder>> ListAsync();
    Task AddAsync(ProductPerOrder productPerOrder);
    Task<ProductPerOrder> FindByIdAsync(int orderId, int productId);
    Task<IEnumerable<ProductPerOrder>> ListByOrderIdAsync(int orderId);
    Task<IEnumerable<ProductPerOrder>> ListByProductIdAsync(int productId);
}