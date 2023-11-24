using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IFranchiseRepository
{
    Task<IEnumerable<Franchise>> ListAsync();
    Task AddAsync(Franchise franchise);
    Task<Franchise> FindByIdAsync(int id);
    Task<IEnumerable<Franchise>> ListByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Franchise>> ListBySubcategoryIdAsync(int subcategoryId);
}