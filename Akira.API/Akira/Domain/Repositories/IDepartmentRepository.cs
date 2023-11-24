using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> ListAsync();
    Task AddAsync(Department department);
    Task<Department> FindByIdAsync(int id);
}