using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IProductImageService
{
    Task<IEnumerable<ProductImage>> ListAsync();
    Task<ProductImageResponse> SaveAsync(ProductImage productimage);
    Task<ProductImageResponse> UpdateAsync(int id, ProductImage productimage);
    Task<ProductImageResponse> DeleteAsync(int id);
}

