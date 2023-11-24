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
public class ImageService: IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="imageRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
    {
        _imageRepository = imageRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<ImageResponse> SaveAsync(Image receivedImage)
    {
        try {
            await _imageRepository.AddAsync(receivedImage);
            await _unitOfWork.CompleteAsync();
            return new ImageResponse(receivedImage);
        }
        catch (Exception e) {
            return new ImageResponse($"Ocurrio un error al guardar la imagen: {e.Message}");
        }
    }
    public async Task<IEnumerable<Image>> ListAsync()
    {
        var images = await _imageRepository.ListAsync();
        return images;
    }
    public async Task<Image> GetImageByIdAsync(int id)
    {
        var image = await _imageRepository.FindByIdAsync(id);
        return image;
    }
}