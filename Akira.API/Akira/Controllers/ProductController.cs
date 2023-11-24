using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductController: ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)  
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources; 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResource>> GetById(int id) 
    {
        var product = await _productService.ListAsync();

        var matchingProduct = product.FirstOrDefault(p => p.Id == id);

        if(matchingProduct == null)
            return NotFound();

        var resource = _mapper.Map<Product, ProductResource>(matchingProduct);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]ProductResource resource) 
    {
        var product = _mapper.Map<ProductResource, Product>(resource);
        var response = await _productService.SaveAsync(product);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }

}