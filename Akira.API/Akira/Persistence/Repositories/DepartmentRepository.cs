using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Responses;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class DepartmentsRepository: BaseRepository, IDepartmentRepository
{
    public DepartmentsRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<Department>> ListAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
    }

    Task<Department> IDepartmentRepository.FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    Task<IEnumerable<Department>> IDepartmentRepository.ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Department> FindByIdAsync(int id)
    {
        return await _context.Departments.FindAsync(id);
    }
}