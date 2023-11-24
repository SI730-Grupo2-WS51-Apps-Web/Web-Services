using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Services;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This is the implementation of the interface IEventService, which contains the
/// methods that will be used to perform actions in the API. In this case, the
/// only method that is implemented is how to create a Event
/// </summary>
public class DepartmentService: IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="departmentRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Department>> ListAsync()
    {
        var departments = await _departmentRepository.ListAsync();
        return departments;
    }

    public Task<DepartmentResponse> SaveAsync(Department department)
    {
        throw new NotImplementedException();
    }
    
    public async  Task<Department> GetDepartmentByIdAsync(int id)
    {
        var department = await _departmentRepository.FindByIdAsync(id);
        return department;
    }
}