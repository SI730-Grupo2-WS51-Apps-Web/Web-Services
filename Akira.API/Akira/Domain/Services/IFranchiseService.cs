using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IFranchiseService
{
    Task<IEnumerable<Franchise>> ListAsync();
    Task<FranchiseResponse> SaveAsync(Franchise franchise);
}

