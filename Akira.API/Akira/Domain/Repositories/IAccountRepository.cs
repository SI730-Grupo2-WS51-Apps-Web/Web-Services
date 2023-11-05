using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IAccountRepository
{
    Task<IEnumerable<Account>> ListAsync();
    Task AddAsync(Account category);
    Task<Account> FindByIdAsync(int id);
    void Update(Account category);
    void Remove(Account category);
    Task<Account> GetAccountByCredentialsAsync(string email, string password);
    Task<Account> GetAccountByEmailAsync(string email);
    Task<IEnumerable<Account>> GetUsersSortedAsync(string sortBy, bool sortOrder);
}