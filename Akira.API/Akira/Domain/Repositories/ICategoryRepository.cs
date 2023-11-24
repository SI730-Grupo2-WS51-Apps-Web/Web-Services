using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category category);
    Task<Category> FindByIdAsync(int id);
}