using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Services;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This is the implementation of the interface IEventService, which contains the
/// methods that will be used to perform actions in the API. In this case, the
/// only method that is implemented is how to create a Event
/// </summary>
public partial class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="orderRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Order>> ListAsync()
    {
        var orders = await _orderRepository.ListAsync();
        return orders;
    }

    public Task<OrderResponse> SaveAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponse> UpdateAsync(int id, Order order)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> ListByUserId(int userId)
    {
        return await _orderRepository.ListByUserIdAsync(userId);
    }

    public async  Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.FindByIdAsync(id);
        return order;
    }
}