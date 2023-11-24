using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class ImageRepository: BaseRepository, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Image>> ListAsync()
    {
        return await _context.Images.ToListAsync();
    }

    public async Task AddAsync(Image image)
    {
        await _context.Images.AddAsync(image);
    }

    public async Task<Image> FindByIdAsync(int id)
    {
        return await _context.Images.FindAsync(id);
    }
}