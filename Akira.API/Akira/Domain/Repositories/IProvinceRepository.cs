using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IProvinceRepository
{
    Task<IEnumerable<Province>> ListAsync();
    Task AddAsync(Province province);
    Task<Province> FindByIdAsync(int id);
    Task<IEnumerable<Province>> ListByDepartmentIdAsync(int departmentId);
}