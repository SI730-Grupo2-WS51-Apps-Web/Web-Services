using Akira.API.Shared.Persistence.Contexts;

namespace Akira.API.Shared.Persistence.Repositories;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This class contains the base repository definition to be implemented
/// on any other repository in the backend. In this case, it's only used
/// for "EventRepository"
/// </summary>
public class BaseRepository
{
    protected readonly AppDbContext _context;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}