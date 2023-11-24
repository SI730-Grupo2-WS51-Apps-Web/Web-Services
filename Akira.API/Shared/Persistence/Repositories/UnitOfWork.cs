using Akira.API.Akira.Domain.Repositories;
using Akira.API.Shared.Persistence.Contexts;

namespace si730pc2u202110062.API.Shared.Persistence.Repositories;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This contains the implementation for the UnitOfWork interface, which
/// determines how to perform an async operation to database
/// </summary>
public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}