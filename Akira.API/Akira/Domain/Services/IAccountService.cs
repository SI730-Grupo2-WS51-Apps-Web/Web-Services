using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IAccountService
{
    Task<IEnumerable<Account>> ListAsync();
    Task<Account> GetAccountByIdAsync(int id);
    Task<AccountResponse> SaveAsync(Account account);
    Task<AccountResponse> UpdateAsync(int id, Account account);
    Task<AccountResponse> DeleteAsync(int id);
    Task<Account> GetAccountByCredentialsAsync(string email, string password);
    Task<Account> GetAccountByEmailAsync(string email);
    Task<IEnumerable<Account>> GetUsersSortedAsync(string sortBy, bool sortOrder);
}

