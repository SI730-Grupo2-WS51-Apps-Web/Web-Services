using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface ICardRepository
{
    Task<IEnumerable<Card>> ListAsync();
    Task AddAsync(Card card);
    Task<Card> FindByIdAsync(int id);
    Task UpdateAsync(Card card);
    Task<Card> FindByUserIdAsync(int userId);
}