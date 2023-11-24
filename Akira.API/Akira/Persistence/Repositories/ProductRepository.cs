using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class ProductRepository: BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    
    
    
    

    public async Task<IEnumerable<Product>> ListByFranchiseIdAsync(int franchiseId)
    {
        return await _context.Products.Where(product => product.FranchiseId == franchiseId).ToListAsync();
    }
    public async Task<IEnumerable<Product>> ListByPriceBetweenAsync(float min, float max)
    {
        return await _context.Products.Where(product => min < product.Price && product.Price < max).ToListAsync();
    }
    public async Task<IEnumerable<Product>> ListByStockAvaliableAsync()
    {
        return await _context.Products.Where(product => product.Stock > 0).ToListAsync();
    }
    public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        return await _context.Products.Where(product => product.CategoryId == categoryId).ToListAsync();
    }
    public async Task<IEnumerable<Product>> ListBySubcategoryIdAsync(int subcategoryId)
    {
        return await _context.Products.Where(product => product.SubcategoryId == subcategoryId).ToListAsync();
    }
}