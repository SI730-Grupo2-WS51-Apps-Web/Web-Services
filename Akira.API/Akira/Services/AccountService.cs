using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Services;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This is the implementation of the interface IEventService, which contains the
/// methods that will be used to perform actions in the API. In this case, the
/// only method that is implemented is how to create a Event
/// </summary>
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="accountRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<AccountResponse> SaveAsync(Account receivedAccount)
    {
        //Don't let the user insert two events with the same phone
        var existsWithSamePhone = await _accountRepository.GetAccountByPhone(receivedAccount.Phone);
        if (existsWithSamePhone != null) return new AccountResponse($"Ya hay un usuario con el telefono {receivedAccount.Phone}");
        
        var existsWithSameUsername = await _accountRepository.GetAccountByCredentialsAsync(receivedAccount.Email, receivedAccount.Password);
        if (existsWithSameUsername != null) return new AccountResponse($"Ya hay un usuario con esas credenciales registrado");
        try
        {
            await _accountRepository.AddAsync(receivedAccount);
            await _unitOfWork.CompleteAsync();
            return new AccountResponse(receivedAccount);
        }
        catch (Exception e)
        {
            return new AccountResponse($"Ocurrio un error al guardar el usuario: {e.Message}");
        }
    }
    public async Task<IEnumerable<Account>> ListAsync()
    {
        var accounts = await _accountRepository.ListAsync();
        return accounts;
    }

    public async  Task<Account> GetAccountByIdAsync(int id)
    {
        var account = await _accountRepository.FindByIdAsync(id);
        return account;
    }
    public async Task<AccountResponse> UpdateAsync(int id, Account updatedAccount)
    {
        var existingAccount = await _accountRepository.FindByIdAsync(id);
        // Verificar si la cuenta existe
        if (existingAccount == null)
        {
            return new AccountResponse($"No se encontró la cuenta con ID {id}");
        }
        // Verificar si hay otra cuenta con el mismo teléfono
        var anotherAccountWithSamePhone = await _accountRepository.GetAccountByPhone(updatedAccount.Phone);
        if (anotherAccountWithSamePhone != null && anotherAccountWithSamePhone.Id != id)
        {
            return new AccountResponse($"Ya hay otra cuenta con el teléfono {updatedAccount.Phone}");
        }
        // Verificar si hay otra cuenta con las mismas credenciales
        var anotherAccountWithSameCredentials = await _accountRepository.GetAccountByCredentialsAsync(updatedAccount.Email, updatedAccount.Password);
        if (anotherAccountWithSameCredentials != null && anotherAccountWithSameCredentials.Id != id)
        {
            return new AccountResponse($"Ya hay otra cuenta con las mismas credenciales");
        }
        // Actualizar los campos de la cuenta existente con los nuevos valores
        existingAccount.FirstName = updatedAccount.FirstName;
        existingAccount.LastName = updatedAccount.LastName;
        existingAccount.Email = updatedAccount.Email;
        existingAccount.Phone = updatedAccount.Phone;
        existingAccount.Address = updatedAccount.Address;
        existingAccount.Card = updatedAccount.Card;
        existingAccount.Cart = updatedAccount.Cart;
        existingAccount.Department = updatedAccount.Department;
        existingAccount.Province = updatedAccount.Province;
        existingAccount.District = updatedAccount.District;
        existingAccount.Genre = updatedAccount.Genre;
        try
        {
            // Guardar los cambios en el repositorio y completar la unidad de trabajo
            await _accountRepository.UpdateAsync(existingAccount);
            await _unitOfWork.CompleteAsync();
            return new AccountResponse(existingAccount);
        }
        catch (Exception e)
        {
            return new AccountResponse($"Ocurrió un error al actualizar la cuenta: {e.Message}");
        }
    }

    public async Task<AccountResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Account> GetAccountByCredentialsAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<Account> GetAccountByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Account>> GetUsersSortedAsync(string sortBy, bool sortOrder)
    {
        throw new NotImplementedException();
    }
}