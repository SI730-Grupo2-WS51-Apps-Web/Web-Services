using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IOrderStatusRepository
{
    Task<IEnumerable<OrderStatus>> ListAsync();
    Task AddAsync(OrderStatus orderStatus);
    Task<OrderStatus> FindByIdAsync(int id);
}