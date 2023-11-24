using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class FranchiseRepository: BaseRepository, IFranchiseRepository
{
    public FranchiseRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Franchise>> ListAsync()
    {
        return await _context.Franchises.ToListAsync();
    }

    public async Task AddAsync(Franchise franchise)
    {
        await _context.Franchises.AddAsync(franchise);
    }

    public async Task<Franchise> FindByIdAsync(int id)
    {
        return await _context.Franchises.FindAsync(id);
    }

    public async Task<IEnumerable<Franchise>> ListByCategoryIdAsync(int categoryId)
    {
        return await _context.Franchises.Where(franchise => franchise.Subcategory.CategoryId == categoryId).ToListAsync();
    }

    public async Task<IEnumerable<Franchise>> ListBySubcategoryIdAsync(int subcategoryId)
    {
        return await _context.Franchises.Where(franchise => franchise.SubcategoryId == subcategoryId).ToListAsync();
    }
}