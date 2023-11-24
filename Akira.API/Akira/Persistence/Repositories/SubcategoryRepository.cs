using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class SubcategoryRepository: BaseRepository, ISubcategoryRepository
{
    public SubcategoryRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Subcategory>> ListAsync()
    {
        return await _context.Subcategories.ToListAsync();
    }

    public async Task AddAsync(Subcategory subcategory)
    {
        await _context.Subcategories.AddAsync(subcategory);
    }

    public async Task<Subcategory> FindByIdAsync(int id)
    {
        return await _context.Subcategories.FindAsync(id);
    }

    public async Task<IEnumerable<Subcategory>> ListByCategoryIdAsync(int categoryId)
    {
        return await _context.Subcategories.Where(subcategory => subcategory.CategoryId == categoryId).ToListAsync();
    }
}