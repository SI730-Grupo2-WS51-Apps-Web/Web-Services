using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface ICardService
{
    Task<IEnumerable<Card>> ListAsync();
    Task<Card> SaveAsync(Card category);
    Task<Card> UpdateAsync(int id, Card category);
    Task<Card> DeleteAsync(int id);
}