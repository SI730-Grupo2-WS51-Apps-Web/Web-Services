using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class AccountRepository: BaseRepository, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Account>> ListAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }

    public async Task<Account> FindByIdAsync(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task UpdateAsync(Account account)
    {
        var existingAccount = await _context.Accounts.FindAsync(account.Id);
        if (existingAccount != null)
        {
            existingAccount.FirstName = account.FirstName;
            existingAccount.LastName = account.LastName;
            existingAccount.Email = account.Email;
            existingAccount.Phone = account.Phone;
            existingAccount.Address = account.Address;
            existingAccount.Card = account.Card;
            existingAccount.Cart = account.Cart;
            existingAccount.Department = account.Department;
            existingAccount.Province = account.Province;
            existingAccount.District = account.District;
            existingAccount.Genre = account.Genre;
        }
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Account account)
    {
        var existingAccount = await _context.Accounts.FindAsync(account.Id);

        // Verificar si la entidad existe
        if (existingAccount != null)
        {
            // Remover la entidad de la base de datos
            _context.Accounts.Remove(existingAccount);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Account> GetAccountByCredentialsAsync(string email, string password)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
    }

    public async Task<Account> GetAccountByEmailAsync(string email)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<IEnumerable<Account>> GetUsersSortedAsync(string sortBy, bool sortOrder)
    {
        throw new NotImplementedException();
    }

    public async Task<Account> GetAccountByPhone(string phone)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.Phone == phone);
    }
}