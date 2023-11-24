using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IAllianceRepository
{
    Task<IEnumerable<Alliance>> ListAsync();
    Task AddAsync(Alliance alliance);
    Task<Alliance> FindByIdAsync(int id);
}