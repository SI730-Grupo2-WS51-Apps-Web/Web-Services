using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;
public interface IImageRepository
{
    Task<IEnumerable<Image>> ListAsync();
    Task AddAsync(Image image);
    Task<Image> FindByIdAsync(int id);
}