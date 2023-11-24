using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class CardRepository: BaseRepository, ICardRepository
{
    public CardRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Card>> ListAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task AddAsync(Card card)
    {
        await _context.Cards.AddAsync(card);
    }

    public async Task<Card> FindByIdAsync(int id)
    {
        return await _context.Cards.FindAsync(id);
    }

    public Task UpdateAsync(Card card)
    {
        throw new NotImplementedException();
    }

    public Task<Card> FindByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}