using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IProvinceService
{
    Task<IEnumerable<Province>> ListAsync();
    Task<ProvinceResponse> SaveAsync(Province province);
}

