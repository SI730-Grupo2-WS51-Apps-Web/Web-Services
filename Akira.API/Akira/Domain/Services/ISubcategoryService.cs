using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface ISubcategoryService
{
    Task<IEnumerable<Subcategory>> ListAsync();
    Task<SubcategoryResponse> SaveAsync(Subcategory subcategory);
    Task<SubcategoryResponse> UpdateAsync(int id, Subcategory subcategory);
    Task<SubcategoryResponse> DeleteAsync(int id);
}

