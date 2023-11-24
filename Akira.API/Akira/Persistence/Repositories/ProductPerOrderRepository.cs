using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class ProductPerOrderRepository: BaseRepository, IProductPerOrderRepository
{
    public ProductPerOrderRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<ProductPerOrder>> ListAsync()
    {
        return await _context.ProductPerOrders.ToListAsync();
    }

    public async Task AddAsync(ProductPerOrder productPerOrder)
    {
        await _context.ProductPerOrders.AddAsync(productPerOrder);
    }

    public async Task<ProductPerOrder> FindByIdAsync(int orderId, int productId)
    {
        
        //POSIBLE FUENTE DE PROBLEMAS:
        return await _context.ProductPerOrders.FindAsync(orderId, productId);
    }
    public async Task<IEnumerable<ProductPerOrder>> ListByOrderIdAsync(int orderId)
    {
        return await _context.ProductPerOrders.Where(PPO => PPO.OrderId == orderId).ToListAsync();
    }
    public async Task<IEnumerable<ProductPerOrder>> ListByProductIdAsync(int productId)
    {
        return await _context.ProductPerOrders.Where(PPO => PPO.ProductId == productId).ToListAsync();
    }

    public async Task<ProductPerOrder> FindByIdAsync(int id)
    {
        return await _context.ProductPerOrders.FindAsync(id);
    }
}