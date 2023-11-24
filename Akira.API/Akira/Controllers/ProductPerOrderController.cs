using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductPerOrderController: ControllerBase
{
    private readonly IProductPerOrderService _productPerOrderService;
    private readonly IMapper _mapper;

    public ProductPerOrderController(IProductPerOrderService productPerOrderService, IMapper mapper)
    {
        _productPerOrderService = productPerOrderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductPerOrderResource>> GetAllAsync()
    {
        var orders = await _productPerOrderService.ListAsync();

        var resources = _mapper.Map<IEnumerable<ProductPerOrder>, IEnumerable<ProductPerOrderResource>>(orders);

        return resources;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductPerOrderResource>> GetById(int id)
    {
        var orders = await _productPerOrderService.ListAsync();

        var order = orders.FirstOrDefault(o => o.OrderId == id);

        if(order == null)
            return NotFound();

        var resource = _mapper.Map<ProductPerOrder, ProductPerOrderResource>(order);

        return resource;
    }
    
    [HttpPost]  
    public async Task<IActionResult> Create([FromBody]ProductPerOrderResource resource)
    {
        var order = _mapper.Map<ProductPerOrderResource, ProductPerOrder>(resource);

        var response = await _productPerOrderService.SaveAsync(order);

        if(!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }
}