using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using Akira.API.Akira.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ImageController: ControllerBase
{
    
    private readonly IImageService _ImageService;
    private readonly IMapper _mapper;
    public ImageController(IImageService ImageService, IMapper mapper)
    {
        _ImageService = ImageService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ImageResponse>> GetAllAsync()
    {
        var Images = await _ImageService.ListAsync();
        //Convierte Image en ImageResource
        var resources = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageResponse>>(Images);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ImageResponse>> GetImageById(int id)
    {
        var Image = await _ImageService.GetImageByIdAsync(id);
        
        if (Image is null)
        {
            return NotFound();
        }

        var ImageResource = _mapper.Map<Image, ImageResponse>(Image);
        
        return ImageResource;
    }
    
  
    [HttpPost]
    public async Task<ActionResult<ImageResponse>> PostImage([FromBody] ImageResource resource)
    {
        var image =  _mapper.Map<ImageResource, Image>(resource);
        var result = await _ImageService.SaveAsync(image);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        var accountResource = _mapper.Map<Image, ImageResponse>(result.Resource);

        return CreatedAtAction(nameof(GetImageById), new { id = accountResource.Id }, accountResource);
    }
    
    
}