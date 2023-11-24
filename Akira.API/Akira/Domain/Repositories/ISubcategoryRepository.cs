using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface ISubcategoryRepository
{
    Task<IEnumerable<Subcategory>> ListAsync();
    Task AddAsync(Subcategory subcategory);
    Task<Subcategory> FindByIdAsync(int id);
    Task<IEnumerable<Subcategory>> ListByCategoryIdAsync(int categoryId);
}