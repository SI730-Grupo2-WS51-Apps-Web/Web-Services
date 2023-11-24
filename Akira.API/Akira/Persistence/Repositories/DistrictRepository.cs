using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Responses;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class DistrictsRepository: BaseRepository, IDistrictRepository
{
    public DistrictsRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<District>> ListAsync()
    {
        return await _context.Districts.ToListAsync();
    }

    public async Task AddAsync(District district)
    {
        await _context.Districts.AddAsync(district);
        await _context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<District>> ListByDepartmentIdAsync(int departmentId)
    {
        var districts = await _context.Districts
            .Where(d => d.Province.DepartmentId == departmentId)
            .ToListAsync();
        return districts;
    }

    public async Task<IEnumerable<District>> ListByProvinceIdAsync(int provinceId)
    {
        var districts = await _context.Districts.Where(d => d.ProvinceId == provinceId)
            .ToListAsync();
        return districts;
    }

    async Task<IEnumerable<District>> IDistrictRepository.ListAsync()
    {
        return await _context.Districts.ToListAsync();
    }

    public async Task<District> FindByIdAsync(int id)
    {
        return await _context.Districts.FindAsync(id);
    }
}