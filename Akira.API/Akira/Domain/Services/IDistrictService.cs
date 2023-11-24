using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IDistrictService
{
    Task<IEnumerable<District>> ListAsync();
    Task<DistrictResponse> SaveAsync(District district);
}

