using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IAllianceService
{
    Task<IEnumerable<Alliance>> ListAsync();
    Task<Alliance> GetAllianceByIdAsync(int id);

    Task<AllianceResponse> SaveAsync(Alliance alliance);
    Task<AllianceResponse> UpdateAsync(int id, Alliance alliance);
    Task<AllianceResponse> DeleteAsync(int id);
    Task<Account> GetAllianceByUrlsAsync(string url);

}

