using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IAccountRepository
{
    Task<IEnumerable<Account>> ListAsync();
    Task AddAsync(Account account);
    Task<Account> FindByIdAsync(int id);
    Task UpdateAsync(Account account);
    Task RemoveAsync(Account account);
    Task<Account> GetAccountByCredentialsAsync(string email, string password);
    Task<Account> GetAccountByEmailAsync(string email);
    Task<IEnumerable<Account>> GetUsersSortedAsync(string sortBy, bool sortOrder);
    Task<Account> GetAccountByPhone(string phone);
}