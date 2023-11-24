using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    
    Task<Order> GetOrderByIdAsync(int id);
    Task<OrderResponse> SaveAsync(Order order);
    Task<OrderResponse> UpdateAsync(int id, Order order);
    Task<OrderResponse> DeleteAsync(int id);
    Task<IEnumerable<Order>> ListByUserId(int userId);
}

