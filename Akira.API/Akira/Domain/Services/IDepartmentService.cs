using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> ListAsync();
    Task<DepartmentResponse> SaveAsync(Department department);
    Task<DepartmentResponse> UpdateAsync(int id, Department department);
    Task<DepartmentResponse> DeleteAsync(int id);
}

