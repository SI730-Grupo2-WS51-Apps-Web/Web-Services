using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface IImageService
{
    Task<IEnumerable<Image>> ListAsync();
    Task<Image> GetImageByIdAsync(int id);

    Task<ImageResponse> SaveAsync(Image image);
}

