using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class WalletRepository: BaseRepository, IWalletRepository
{
    public WalletRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Wallet>> ListAsync()
    {
        return await _context.Wallets.ToListAsync();
    }

    public async Task AddAsync(Wallet wallet)
    {
        await _context.Wallets.AddAsync(wallet);
    }

    public async Task<Wallet> FindByIdAsync(int id)
    {
        return await _context.Wallets.FindAsync(id);
    }
}