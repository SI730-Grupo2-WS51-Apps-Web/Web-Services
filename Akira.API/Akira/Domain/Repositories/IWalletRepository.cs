using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IWalletRepository
{
    Task<IEnumerable<Wallet>> ListAsync();
    Task AddAsync(Wallet wallet);
    Task<Wallet> FindByIdAsync(int id);
}