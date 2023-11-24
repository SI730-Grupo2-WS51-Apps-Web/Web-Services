using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class OrderStatusRepository: BaseRepository, IOrderStatusRepository
{
    public OrderStatusRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<OrderStatus>> ListAsync()
    {
        return await _context.OrderStatus.ToListAsync();
    }

    public async Task AddAsync(OrderStatus orderStatus)
    {
        await _context.OrderStatus.AddAsync(orderStatus);
    }

    public async Task<OrderStatus> FindByIdAsync(int id)
    {
        return await _context.OrderStatus.FindAsync(id);
    }
}