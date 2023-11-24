using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class ProductImageRepository: BaseRepository, IProductImageRepository
{
    public ProductImageRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<ProductImage>> ListAsync()
    {
        return await _context.ProductImages.ToListAsync();
    }

    public async Task AddAsync(ProductImage productImage)
    {
        await _context.ProductImages.AddAsync(productImage);
    }

    public async Task<ProductImage> FindByIdAsync(int id)
    {
        return await _context.ProductImages.FindAsync(id);
    }
}