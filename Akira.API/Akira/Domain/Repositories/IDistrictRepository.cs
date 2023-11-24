using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IDistrictRepository
{
    Task<IEnumerable<District>> ListAsync();
    Task AddAsync(District district);
    Task<District> FindByIdAsync(int id);
    Task<IEnumerable<District>> ListByDepartmentIdAsync(int departmentId);
    Task<IEnumerable<District>> ListByProvinceIdAsync(int provinceId);
}