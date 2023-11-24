using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController] 
[Route("/api/v1/[controller]")]
public class ProductImageController: ControllerBase
{
    private readonly IProductImageService _productImageService;  
    private readonly IMapper _mapper;

    public ProductImageController(IProductImageService productImageService, IMapper mapper)
    {
        _productImageService = productImageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductImageResource>> GetAllAsync()
    {
        var images = await _productImageService.ListAsync();
    
        var resources = _mapper.Map<IEnumerable<ProductImage>, IEnumerable<ProductImageResource>>(images);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]ProductImageResource resource)
    {  
        var image = _mapper.Map<ProductImageResource, ProductImage>(resource);

        var response = await _productImageService.SaveAsync(image);

        if(!response.Success)
            return BadRequest(response);
      
        return Ok(response); 
    }
}