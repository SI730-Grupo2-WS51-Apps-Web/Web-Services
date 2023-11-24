using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class CategoryRepository: BaseRepository, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task<Category> FindByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
}