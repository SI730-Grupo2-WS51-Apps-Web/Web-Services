using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Responses;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class ProvincesRepository: BaseRepository, IProvinceRepository
{
    public ProvincesRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Province>> ListAsync()
    {
        return await _context.Provinces.ToListAsync();
    }

    public async Task AddAsync(Province province)
    {
        await _context.Provinces.AddAsync(province);
        await _context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Province>> ListByDepartmentIdAsync(int departmentId)
    {
        var provinces = await _context.Provinces
            .Where(d => d.DepartmentId == departmentId)
            .ToListAsync();
        return provinces;
    }
    

    public async Task<Province> FindByIdAsync(int id)
    {
        return await _context.Provinces.FindAsync(id);
    }
}