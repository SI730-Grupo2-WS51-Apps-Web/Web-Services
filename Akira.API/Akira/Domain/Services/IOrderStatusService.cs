using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IOrderStatusService
{
    Task<IEnumerable<OrderStatus>> ListAsync();
    Task<OrderStatus> GetOrderStatusByIdAsync(int id);

    Task<OrderStatusResponse> SaveAsync(OrderStatus orderstatus);
    Task<OrderStatusResponse> UpdateAsync(int id, OrderStatus orderstatus);
    Task<OrderStatusResponse> DeleteAsync(int id);
}

