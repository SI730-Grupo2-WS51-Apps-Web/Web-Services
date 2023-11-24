using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class OrderRepository: BaseRepository, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order> FindByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> ListByUserIdAsync(int userId)
    {
        return await _context.Orders.Where(orders => orders.UserId == userId).ToListAsync();
    }
}