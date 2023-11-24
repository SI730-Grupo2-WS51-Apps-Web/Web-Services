using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IAllianceService
{
    Task<IEnumerable<Alliance>> ListAsync();
    Task<Alliance> GetAllianceByIdAsync(int id);
}

