using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class AllianceRepository: BaseRepository, IAllianceRepository
{
    public AllianceRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Alliance>> ListAsync()
    {
        return await _context.Alliances.ToListAsync();
    }

    public async Task AddAsync(Alliance alliance)
    {
        await _context.Alliances.AddAsync(alliance);
    }

    public async Task<Alliance> FindByIdAsync(int id)
    {
        return await _context.Alliances.FindAsync(id);
    }
}