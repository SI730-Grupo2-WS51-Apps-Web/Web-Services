using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IWalletService
{
    Task<IEnumerable<Wallet>> ListAsync();
    Task<WalletResponse> SaveAsync(Wallet wallet);
    Task<WalletResponse> UpdateAsync(int id, Wallet wallet);
    Task<WalletResponse> DeleteAsync(int id);
}

